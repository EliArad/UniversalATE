using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GSkinLib
{
	/// <summary>
	/// Summary description for BitmapRegion.
	/// </summary>
	public class GuiBackground
	{
        static object m_lock = new object();
        static Color m_colorTransparent = Color.Transparent;

        public GuiBackground()
		{}

        public enum WITH_AS
        {
            CONTROL,
            IMAGE
        }
        static string m_baseDir;
        public static void BaseDir(string dir)
        {
            m_baseDir = dir;
        }

        public static Bitmap GetBitmap(string name, int width, int height)
        { 
            
            return null;
        }


        /// <summary>
        /// Create and apply the region on the supplied control
        /// </summary>
        /// <param name="control">The Control object to apply the region to</param>
        /// <param name="bitmap">The Bitmap object to create the region from</param>
        public static void CreateControlRegion(Control control, Bitmap bitmap, WITH_AS widthAs = WITH_AS.CONTROL)
		{

            lock (m_lock)
            {
                // Return if control and bitmap are null
                if (control == null || bitmap == null)
                    return;

                if (widthAs == WITH_AS.IMAGE)
                {
                    // Set our control's size to be the same as the bitmap
                    control.Width = bitmap.Width;
                    control.Height = bitmap.Height;
                }
                
                 

                // Check if we are dealing with Form here
                if (control is System.Windows.Forms.UserControl)
                {


                    // Cast to a Form object
                    UserControl form = (UserControl)control;

                    // Set our form's size to be a little larger that the bitmap just 
                    // in case the form's border style is not set to none in the first place
                    form.Width += 15;
                    form.Height += 35;

                    // No border
                    //form.FormBorderStyle = FormBorderStyle.None;

                    // Set bitmap as the background image
                    form.BackgroundImage = bitmap;

                    

                    // Calculate the graphics path based on the bitmap supplied
                    //GraphicsPath graphicsPath = CalculateControlGraphicsPath(bitmap);
                    // Apply new region
                    //form.Region = new Region(graphicsPath);

                    try
                    {
                        form.Region = MakeNonTransparentRegion(bitmap);
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }


                }
                if (control is System.Windows.Forms.Form)
                {
                    // Cast to a Form object
                    Form form = (Form)control;

                    // Set our form's size to be a little larger that the bitmap just 
                    // in case the form's border style is not set to none in the first place
                    //form.Width += 15;
                    //form.Height += 35;

                    // No border
                    form.FormBorderStyle = FormBorderStyle.None;

                    // Set bitmap as the background image
                    form.BackgroundImage = bitmap;
                    

                    // Calculate the graphics path based on the bitmap supplied
                    //GraphicsPath graphicsPath = CalculateControlGraphicsPath(bitmap);
                    // Apply new region
                    //form.Region = new Region(graphicsPath);

                    form.Region = MakeNonTransparentRegion(bitmap);

                }

                // Check if we are dealing with Button here
                else if (control is System.Windows.Forms.Button)
                {
                    // Cast to a button object
                    Button button = (Button)control;

                      
                    // Change cursor to hand when over button
                    button.Cursor = Cursors.Hand;

                    // Set background image of button
                    button.BackgroundImage = bitmap;
                    if (widthAs == WITH_AS.CONTROL)
                    {
                        button.BackgroundImageLayout = ImageLayout.Stretch;
                        bitmap = new Bitmap(bitmap, new Size(button.Width, button.Height));
                    }

                    // Calculate the graphics path based on the bitmap supplied
                    //GraphicsPath graphicsPath = CalculateControlGraphicsPath(bitmap);
                    // Apply new region
                    //button.Region = new Region(graphicsPath);

                    button.Region = MakeNonTransparentRegion(bitmap);

                }
            }
		}

        // Make a region representing the
        // image's non-transparent pixels.
        static Region MakeNonTransparentRegion(Bitmap bm)
        {
            try
            {
                if (bm == null) return null;

                // Make the result region.
                Region result = new Region();
                result.MakeEmpty();

                Rectangle rect = new Rectangle(0, 0, 1, 1);
                bool in_image = false;
                for (int y = 0; y < bm.Height; y++)
                {
                    for (int x = 0; x < bm.Width; x++)
                    {
                        if (!in_image)
                        {
                            // We're not now in the non-transparent pixels.
                            if (bm.GetPixel(x, y).A != 0)
                            {
                                // We just started into non-transparent pixels.
                                // Start a Rectangle to represent them.
                                in_image = true;
                                rect.X = x;
                                rect.Y = y;
                                rect.Height = 1;
                            }
                        }
                        else if (bm.GetPixel(x, y).A == 0)
                        {
                            // We are in the non-transparent pixels and
                            // have found a transparent one.
                            // Add the rectangle so far to the region.
                            in_image = false;
                            rect.Width = (x - rect.X);
                            result.Union(rect);
                        }
                    }

                    // Add the final piece of the rectangle if necessary.
                    if (in_image)
                    {
                        in_image = false;
                        rect.Width = (bm.Width - rect.X);
                        result.Union(rect);
                    }
                }

                return result;
            }
            catch (Exception err)
            {
                Region result = new Region();
                result.MakeEmpty();
                return result;
            }
        }

        /// <summary>
        /// Calculate the graphics path that representing the figure in the bitmap 
        /// excluding the transparent color which is the top left pixel.
        /// </summary>
        /// <param name="bitmap">The Bitmap object to calculate our graphics path from</param>
        /// <returns>Calculated graphics path</returns>
        private static GraphicsPath CalculateControlGraphicsPath(Bitmap bitmap)
		{
			// Create GraphicsPath for our bitmap calculation
			GraphicsPath graphicsPath = new GraphicsPath();

			// Use the top left pixel as our transparent color
			Color colorTransparent = m_colorTransparent;

			// This is to store the column value where an opaque pixel is first found.
			// This value will determine where we start scanning for trailing opaque pixels.
			int colOpaquePixel = 0;

			// Go through all rows (Y axis)
			for(int row = 0; row < bitmap.Height; row ++)
			{
				// Reset value
				colOpaquePixel = 0;

				// Go through all columns (X axis)
				for(int col = 0; col < bitmap.Width; col ++)
				{
					// If this is an opaque pixel, mark it and search for anymore trailing behind
					if(bitmap.GetPixel(col, row) != colorTransparent)
					{
						// Opaque pixel found, mark current position
						colOpaquePixel = col;

						// Create another variable to set the current pixel position
						int colNext = col;

						// Starting from current found opaque pixel, search for anymore opaque pixels 
						// trailing behind, until a transparent pixel is found or minimum width is reached
						for(colNext = colOpaquePixel; colNext < bitmap.Width; colNext ++)
							if(bitmap.GetPixel(colNext, row) == colorTransparent)
								break;

						// Form a rectangle for line of opaque pixels found and add it to our graphics path
						graphicsPath.AddRectangle(new Rectangle(colOpaquePixel, row, colNext - colOpaquePixel, 1));

						// No need to scan the line of opaque pixels just found
						col = colNext;
					}
				}
			}

			// Return calculated graphics path
			return graphicsPath;
		}
	}
}
