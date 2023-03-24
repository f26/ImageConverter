using ImageConverter.Properties;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq.Expressions;

namespace ImageConverter
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            comboBoxQuality.SelectedIndex = 7;
            HandleOptionUpdate(null, null);
            FormMain_Resize(null, null);

            if (Directory.Exists(Settings.Default.OutputDir))
            {
                textBoxOutputPath.Text = Settings.Default.OutputDir;
            }

            if (Settings.Default.Format == ".jpg") rbFormatJPG.Checked = true;
            if (Settings.Default.Format == ".bmp") rbFormatBMP.Checked = true;
            if (Settings.Default.Format == ".png") rbFormatPNG.Checked = true;

            comboBoxQuality.SelectedIndex = Settings.Default.JpgQuality;

            switch (Settings.Default.DimOption)
            {
                case "NoChange": rbDimNoChange.Checked = true; break;
                case "25": rbDim25.Checked = true; break;
                case "50": rbDim50.Checked = true; break;
                case "75": rbDim75.Checked = true; break;
                case "FixedWidth": rbDimFixedWidth.Checked = true; break;
                case "FixedHeight": rbDimFixedHeight.Checked = true; break;
                case "FixedWidthAndHeight": rbDimFixedWidthAndHeight.Checked = true; break;
                case "Megapixels": rbDimMegapixels.Checked = true; break;
                case "MaxWidth": rbDimMaxWidth.Checked = true; break;
                case "MaxHeight": rbDimMaxHeight.Checked = true; break;
                case "MaxWidthAndHeight": rbDimMaxWidthAndHeight.Checked = true; break;
            }

            textBoxDimX.Text = Settings.Default.DimX;
            textBoxDimY.Text = Settings.Default.DimY;
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(textBoxOutputPath.Text))
            {
                toolStripStatusLabel1.Text = "ERROR: Output directory does not exist";
                return;
            }

            try
            {
                buttonConvert.Enabled = textBoxOutputPath.Enabled = groupBox1.Enabled = groupBox2.Enabled = listBoxImages.Enabled = false;
                Settings.Default.OutputDir = textBoxOutputPath.Text;
                Settings.Default.Save();

                foreach (string filename in listBoxImages.Items)
                {
                    toolStripStatusLabel1.Text = filename;
                    Application.DoEvents();

                    // Load the image
                    Image img = Image.FromFile(filename);

                    // Determine output filename/format
                    string ext = ".jpg";
                    ImageFormat format = ImageFormat.Jpeg;
                    if (rbFormatBMP.Checked) { format = ImageFormat.Bmp; ext = ".bmp"; }
                    if (rbFormatPNG.Checked) { format = ImageFormat.Png; ext = ".png"; }
                    string outputFile = Path.GetFullPath(textBoxOutputPath.Text) + "\\" + Path.GetFileNameWithoutExtension(filename) + ext;

                    // Determine quality (JPG only)
                    EncoderParameters encoderParameters = null;
                    if (format == ImageFormat.Jpeg)
                    {
                        long quality = Convert.ToUInt32(comboBoxQuality.Text);
                        encoderParameters = new EncoderParameters(1);
                        encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                        img.Save(outputFile, format);
                    }

                    // Determine new image dimensions
                    if (rbDim25.Checked)
                    {
                        int newWidth = (int)(img.Width * 0.25);
                        int newHeight = (int)(img.Height * 0.25);
                        img = ResizeImage(img, newWidth, newHeight);
                    }
                    else if (rbDim50.Checked)
                    {
                        int newWidth = (int)(img.Width * 0.5);
                        int newHeight = (int)(img.Height * 0.5);
                        img = ResizeImage(img, newWidth, newHeight);
                    }
                    else if (rbDim75.Checked)
                    {
                        int newWidth = (int)(img.Width * 0.75);
                        int newHeight = (int)(img.Height * 0.75);
                        img = ResizeImage(img, newWidth, newHeight);
                    }
                    else if (rbDimFixedWidth.Checked)
                    {
                        int newWidth = Convert.ToInt32(textBoxDimX.Text);
                        int newHeight = (newWidth * img.Height) / img.Width;
                        img = ResizeImage(img, newWidth, newHeight);
                    }
                    else if (rbDimFixedHeight.Checked)
                    {
                        int newHeight = Convert.ToInt32(textBoxDimY.Text);
                        int newWidth = (newHeight * img.Width) / img.Height;
                        img = ResizeImage(img, newWidth, newHeight);
                    }
                    else if (rbDimFixedWidthAndHeight.Checked)
                    {
                        int newWidth = Convert.ToInt32(textBoxDimX.Text);
                        int newHeight = Convert.ToInt32(textBoxDimY.Text);
                        img = ResizeImage(img, newWidth, newHeight);
                    }
                    else if (rbDimMegapixels.Checked)
                    {
                        // Two equations, two unknowns:
                        // newX*newY=MP
                        // newX/newY=X/Y

                        // Solving:
                        // newX = (X/Y)*newY
                        // (X/Y)*newY*newY = MP
                        // newY*newY = MP/(X/Y)

                        // Finally:
                        // newY = sqrt(MP/(X/Y))
                        // newX = MP/newY

                        double mp = Convert.ToDouble(textBoxDimX.Text) * 1000000;
                        double newY = Math.Sqrt(mp / (((double)img.Width) / img.Height));
                        double newX = mp / newY;
                        img = ResizeImage(img, (int)newX, (int)newY);
                    }
                    else if (rbDimMaxWidth.Checked)
                    {
                        int newWidth = Convert.ToInt32(textBoxDimX.Text);
                        int newHeight = (newWidth * img.Height) / img.Width;

                        if (img.Width > newWidth)
                            img = ResizeImage(img, newWidth, newHeight);
                    }
                    else if (rbDimMaxHeight.Checked)
                    {
                        int newHeight = Convert.ToInt32(textBoxDimY.Text);
                        int newWidth = (newHeight * img.Width) / img.Height;
                        if (img.Height > newHeight)
                            img = ResizeImage(img, newWidth, newHeight);
                    }
                    else if (rbDimMaxWidthAndHeight.Checked)
                    {
                        int newWidthA = Convert.ToInt32(textBoxDimX.Text);
                        int newHeightA = (newWidthA * img.Height) / img.Width;

                        int newHeightB = Convert.ToInt32(textBoxDimY.Text);
                        int newWidthB = (newHeightB * img.Width) / img.Height;

                        if (img.Width > newWidthA || img.Width > newWidthB)
                            if (newWidthA <= newWidthB)
                                img = ResizeImage(img, newWidthA, newHeightA);
                            else
                                img = ResizeImage(img, newWidthB, newHeightB);
                        else if (img.Height > newHeightA || img.Height > newHeightB)
                            if (newHeightA <= newHeightB)
                                img = ResizeImage(img, newWidthA, newHeightA);
                            else
                                img = ResizeImage(img, newWidthB, newHeightB);
                    }

                    img.Save(outputFile, GetEncoder(format), encoderParameters);
                }

                toolStripStatusLabel1.Text = "Ready";
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "ERROR: " + ex.Message;
            }
            finally
            {
                buttonConvert.Enabled = textBoxOutputPath.Enabled = groupBox1.Enabled = groupBox2.Enabled = listBoxImages.Enabled = true;
            }

            HandleOptionUpdate(null, null);
        }

        // https://efundies.com/csharp-save-jpg/
        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            var codecs = ImageCodecInfo.GetImageDecoders();
            foreach (var codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private void HandleOptionUpdate(object sender, EventArgs e)
        {
            // Enable/disable JPG quality GUI elements only if JPG output is selected
            labelQuality.Visible = comboBoxQuality.Visible = rbFormatJPG.Checked;

            // Move/make visible the input text boxes depending on which dimension option is selected
            if (rbDimNoChange.Checked || rbDim25.Checked || rbDim50.Checked || rbDim75.Checked)
            {
                textBoxDimX.Visible = textBoxDimY.Visible = false;
            }
            if (rbDimFixedWidth.Checked)
            {
                textBoxDimX.Visible = textBoxDimY.Visible = true;
                textBoxDimX.Enabled = true;
                textBoxDimY.Enabled = false;
                textBoxDimX.Top = textBoxDimY.Top = rbDimFixedWidth.Top - 3;
            }
            if (rbDimFixedHeight.Checked)
            {
                textBoxDimX.Visible = textBoxDimY.Visible = true;
                textBoxDimX.Enabled = false;
                textBoxDimY.Enabled = true;
                textBoxDimX.Top = textBoxDimY.Top = rbDimFixedHeight.Top - 3;
            }
            if (rbDimFixedWidthAndHeight.Checked)
            {
                textBoxDimX.Visible = textBoxDimY.Visible = true;
                textBoxDimX.Enabled = textBoxDimY.Enabled = true;
                textBoxDimX.Top = textBoxDimY.Top = rbDimFixedWidthAndHeight.Top - 3;
            }
            if (rbDimMegapixels.Checked)
            {
                textBoxDimX.Visible = true;
                textBoxDimY.Visible = false;
                textBoxDimX.Enabled = true;
                textBoxDimX.Top = rbDimMegapixels.Top - 3;
            }
            if (rbDimMaxWidth.Checked)
            {
                textBoxDimX.Visible = textBoxDimY.Visible = true;
                textBoxDimX.Enabled = true;
                textBoxDimY.Enabled = false;
                textBoxDimX.Top = textBoxDimY.Top = rbDimMaxWidth.Top - 3;
            }
            if (rbDimMaxHeight.Checked)
            {
                textBoxDimX.Visible = textBoxDimY.Visible = true;
                textBoxDimX.Enabled = false;
                textBoxDimY.Enabled = true;
                textBoxDimX.Top = textBoxDimY.Top = rbDimMaxHeight.Top - 3;
            }
            if (rbDimMaxWidthAndHeight.Checked)
            {
                textBoxDimX.Visible = textBoxDimY.Visible = true;
                textBoxDimX.Enabled = textBoxDimY.Enabled = true;
                textBoxDimX.Top = textBoxDimY.Top = rbDimMaxWidthAndHeight.Top - 3;
            }

            // Look for dupes and color the GUI accordingly
            bool dupeFound = false;
            Dictionary<string, string> outputFilenames = new Dictionary<string, string>();
            foreach (string filename in listBoxImages.Items)
            {
                string ext = ".jpg";
                ImageFormat format = ImageFormat.Jpeg;
                if (rbFormatBMP.Checked) { format = ImageFormat.Bmp; ext = ".bmp"; }
                if (rbFormatPNG.Checked) { format = ImageFormat.Png; ext = ".png"; }
                string outputFile = Path.GetFullPath(textBoxOutputPath.Text) + "\\" + Path.GetFileNameWithoutExtension(filename) + ext;
                if (outputFilenames.ContainsKey(outputFile) || File.Exists(outputFile))
                {
                    dupeFound = true;
                    break;
                }
                else
                {
                    outputFilenames.Add(outputFile, outputFile);
                }
            }
            if (dupeFound)
            {
                buttonConvert.ForeColor = Color.Red;
                toolTip1.SetToolTip(buttonConvert, "WARNING: Duplicate output names exist.  Files will be overwritten.");

            }
            else
            {
                buttonConvert.ForeColor = Color.Black;
                toolTip1.RemoveAll();
            }
        }

        // https://stackoverflow.com/questions/1922040/how-to-resize-an-image-c-sharp
        private Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                listBoxImages.Items.Clear();
                foreach (string file in files)
                {
                    FileInfo finfo = new FileInfo(file);
                    if (finfo.Extension.ToLower() == ".jpg" ||
                       finfo.Extension.ToLower() == ".bmp" ||
                       finfo.Extension.ToLower() == ".png")
                    {
                        listBoxImages.Items.Add(file);
                    }
                }

                HandleOptionUpdate(null, null);
            }
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            listBoxImages.Width = this.ClientSize.Width - listBoxImages.Left - 10;
            listBoxImages.Height = this.ClientSize.Height - listBoxImages.Top - statusStrip1.Height;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rbFormatJPG.Checked) Settings.Default.Format = ".jpg";
            if (rbFormatBMP.Checked) Settings.Default.Format = ".bmp";
            if (rbFormatPNG.Checked) Settings.Default.Format = ".png";

            Settings.Default.JpgQuality = comboBoxQuality.SelectedIndex;

            if (rbDimNoChange.Checked) Settings.Default.DimOption = "NoChange";
            if (rbDim25.Checked) Settings.Default.DimOption = "25";
            if (rbDim50.Checked) Settings.Default.DimOption = "50";
            if (rbDim75.Checked) Settings.Default.DimOption = "75";
            if (rbDimFixedWidth.Checked) Settings.Default.DimOption = "FixedWidth";
            if (rbDimFixedHeight.Checked) Settings.Default.DimOption = "FixedHeight";
            if (rbDimFixedWidthAndHeight.Checked) Settings.Default.DimOption = "FixedWidthAndHeight";
            if (rbDimMegapixels.Checked) Settings.Default.DimOption = "Megapixels";
            if (rbDimMaxWidth.Checked) Settings.Default.DimOption = "MaxWidth";
            if (rbDimMaxHeight.Checked) Settings.Default.DimOption = "MaxHeight";
            if (rbDimMaxWidthAndHeight.Checked) Settings.Default.DimOption = "MaxWidthAndHeight";

            Settings.Default.DimX = textBoxDimX.Text;
            Settings.Default.DimY = textBoxDimY.Text;

            Settings.Default.Save();
        }
    }
}