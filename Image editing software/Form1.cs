using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_editing_software
{
    public partial class Form1 : Form
    {
        PictureBox[] pictureBoxes = new PictureBox[4];
        Image[] imagelst = new Image[4];
        Image file;
        Boolean fileopen = false;
        static readonly object _object = new object();
        private static object Lock = new object();

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeOpenFileDialog();
        }

        public Form1()
        {
            InitializeComponent();

            pictureBoxes[0] = pictureBox1;
            pictureBoxes[1] = pictureBox2;
            pictureBoxes[2] = pictureBox3;
            pictureBoxes[3] = pictureBox4;
        }

        private void InitializeOpenFileDialog()
        {
            // Set the file dialog to filter for graphics files.
            this.openFileDialog1.Filter =
                "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" +
                "All files (*.*)|*.*";

            // Allow the user to select multiple images.
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "My Image Browser";
        }
        //open a image for picture box
        void openimage1()
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                file = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = file;
                imagelst[0] = file;
                fileopen = true;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        //open a image for picture box
        void openimage2()
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                file = Image.FromFile(openFileDialog1.FileName);
                pictureBox2.Image = file;
                imagelst[1] = file;
                fileopen = true;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }
        //open a image for picture box
        void openimage3()
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                file = Image.FromFile(openFileDialog1.FileName);
                pictureBox3.Image = file;
                imagelst[2] = file;
                fileopen = true;
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }
        //open a image for picture box
        void openimage4()
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                file = Image.FromFile(openFileDialog1.FileName);
                pictureBox4.Image = file;
                imagelst[3] = file;
                fileopen = true;
                pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }
        // save picture for the hard drive
        void save1()
        {
            if (fileopen)
            {
                SaveFileDialog s = new SaveFileDialog();
                s.Filter = "Images |*.png;*.bmp;*.jpeg,*.jpg;*";
                ImageFormat format = ImageFormat.Png;
                if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    String t = Path.GetExtension(s.FileName);
                    switch (t)
                    {
                        case ".jpeg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                    }
                    pictureBox1.Image.Save(s.FileName, format);

                }
                else
                {
                    MessageBox.Show("error");

                }
            }
        }
        // save picture for the hard drive
        void save2()
        {
            if (fileopen)
            {
                SaveFileDialog s = new SaveFileDialog();
                s.Filter = "Images |*.png;*.bmp;*.jpeg,*.jpg;*";
                ImageFormat format = ImageFormat.Png;
                if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    String t = Path.GetExtension(s.FileName);
                    switch (t)
                    {
                        case ".jpeg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                    }
                    pictureBox2.Image.Save(s.FileName, format);

                }
                else
                {
                    MessageBox.Show("error");

                }
            }
        }
        // save picture for the hard drive
        void save3()
        {
            if (fileopen)
            {
                SaveFileDialog s = new SaveFileDialog();
                s.Filter = "Images |*.png;*.bmp;*.jpeg,*.jpg;*";
                ImageFormat format = ImageFormat.Png;
                if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    String t = Path.GetExtension(s.FileName);
                    switch (t)
                    {
                        case ".jpeg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                    }
                    pictureBox3.Image.Save(s.FileName, format);

                }
                else
                {
                    MessageBox.Show("error");

                }
            }
        }
        // save picture for the hard drive
        void save4()
        {
            if (fileopen)
            {
                SaveFileDialog s = new SaveFileDialog();
                s.Filter = "Images |*.png;*.bmp;*.jpeg,*.jpg;*";
                ImageFormat format = ImageFormat.Png;
                if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    String t = Path.GetExtension(s.FileName);
                    switch (t)
                    {
                        case ".jpeg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                    }
                    pictureBox4.Image.Save(s.FileName, format);

                }
                else
                {
                    MessageBox.Show("error");

                }
            }
        }
        // save picture for the hard drive
        void ImageFlip(Image img)
        {
            if (!fileopen)
            {
                MessageBox.Show("error");
            }
            else
            {
                img.RotateFlip(RotateFlipType.Rotate180FlipY);
            }
        }

        // reset all applied effects
        void resetImage()
        {
            if (!fileopen)
            {
                MessageBox.Show("Picture is not loaded");

            }
            else
            {
                if (fileopen)
                {
                    file = Image.FromFile(openFileDialog1.FileName);
                    pictureBox1.Image = imagelst[0];
                    pictureBox2.Image = imagelst[1];
                    pictureBox3.Image = imagelst[2];
                    pictureBox4.Image = imagelst[3];
                }
            }
        }
        // implement the grayscale effect method
        void grayscale(Bitmap bmpin, Image img)
        {

            if (!fileopen)

            {
                MessageBox.Show("Open an Image then apply changes");

            }
            else
            {

                ImageAttributes imgAtt = new ImageAttributes();
                ColorMatrix colour = new ColorMatrix(new float[][]
                {
                    new float[]{0.299f,0.299f,0.299f,0,0},
                    new float[]{0.587f,0.587f,0.587f,0,0},
                    new float[]{0.114f, 0.114f, 0.114f, 0,0},
                    new float[]{0,0,0,1,0},
                     new float[]{0,0,0,0,0},
                });
                imgAtt.SetColorMatrix(colour);
                Graphics gr = Graphics.FromImage(bmpin);

                gr.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAtt);
                gr.Dispose();


            }
        }

        // implement the rotate effect method
        void rotate(Image bmp)
        {
            if (!fileopen)
            {
                MessageBox.Show("eroor");

            }
            else
            {
                bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
        }
        // implement the blossome effect method
        void blossome(Bitmap bmpin, Image img)
        {

            if (!fileopen)

            {
                MessageBox.Show("Open an Image then apply changes");

            }
            else
            {
                ImageAttributes imgAtt = new ImageAttributes();
                ColorMatrix colour = new ColorMatrix(new float[][]
                {
                    new float[]{1,0,0,0,0},
                    new float[]{0,1,0,0,0},
                    new float[]{.50f, 0,1,0,0},
                    new float[]{0,0,0,1,0},
                     new float[]{0,0,0,0,1},
                });
                imgAtt.SetColorMatrix(colour);
                Graphics gr = Graphics.FromImage(bmpin);

                gr.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAtt);
                gr.Dispose();


            }
        }
        // implement the sapia effect method
        void sapia(Bitmap bmpin, Image img)
        {

            if (!fileopen)

            {
                MessageBox.Show("Open an Image then apply changes");

            }
            else
            {
                ImageAttributes imgAtt = new ImageAttributes();
                ColorMatrix colour = new ColorMatrix(new float[][]
                {
                    new float[]{ 0.393f, 0.349f, 0.272f, 0,0},
                    new float[]{ 0.769f, 0.686f, 0.534f, 0,0},
                    new float[]{ 0.189f, 0.168f, 0.131f, 0,0},
                    new float[]{0,0,0,1,0},
                     new float[]{0,0,0,0,1},
                });
                imgAtt.SetColorMatrix(colour);
                Graphics gr = Graphics.FromImage(bmpin);

                gr.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAtt);
                gr.Dispose();


            }
        }
        // implement the invert effect method
        void Invert(Bitmap bmpin, Image img)
        {

            if (!fileopen)

            {
                MessageBox.Show("Open an Image then apply changes");

            }
            else
            {
                ImageAttributes imgAtt = new ImageAttributes();
                ColorMatrix colour = new ColorMatrix(new float[][]
                {
                    new float[] {-1, 0, 0, 0, 0},
                    new float[] {0, -1, 0, 0, 0},
                    new float[] {0, 0, -1, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {1, 1, 1, 0, 1}
                });
                imgAtt.SetColorMatrix(colour);
                Graphics gr = Graphics.FromImage(bmpin);

                gr.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAtt);
                gr.Dispose();


            }
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        //calling the methods for open images
        private void button1_Click(object sender, EventArgs e)
        {
            openimage1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openimage2();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            openimage3();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            openimage4();
        }
        //calling the methods for save images
        private void button3_Click(object sender, EventArgs e)
        {
            save1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            save2();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            save3();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            save4();
        }
        //calling the methods for reset  effects in images
        private void button5_Click(object sender, EventArgs e)
        {
            resetImage();
        }

        //implementing grayscale button click event
        private void button6_Click(object sender, EventArgs e)
        {
            if (!fileopen)
            {
                MessageBox.Show("open a picture");
            }

            else
            {


                try
                {


                    Parallel.ForEach(pictureBoxes, p =>
                    {
                        lock (_object)
                        {
                            Image image = p.Image;
                            Bitmap bmpInverted = new Bitmap(image.Width, image.Height);
                            grayscale(bmpInverted, image);
                            p.Image = bmpInverted;

                        }

                    });
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
        }
        //implementing   blossome button click event
        private void button7_Click(object sender, EventArgs e)
        {
            if (!fileopen)
            {
                MessageBox.Show("open a picture");
            }
            else
            {


                try
                {


                    Parallel.ForEach(pictureBoxes, p =>
                    {
                        lock (_object)
                        {
                            Image image = p.Image;
                            Bitmap bmpInverted = new Bitmap(image.Width, image.Height);
                            blossome(bmpInverted, image);
                            p.Image = bmpInverted;

                        }

                    });
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }

        }

        //implementing   rotate button click event
        private void button8_Click(object sender, EventArgs e)
        {
            if (!fileopen)
            {
                MessageBox.Show("open a picture");
            }
            else
            {

                try
                {
                    Parallel.ForEach(pictureBoxes, p =>
                    {
                        lock (_object)
                        {
                            Image image = p.Image;

                            rotate(image);
                            p.Image = image;

                        }

                    });


                }
                catch (Exception ext)
                {
                    MessageBox.Show(ext.ToString());
                }
            }
        }
        //implementing   imageflip button click event
        private void button9_Click(object sender, EventArgs e)
        {
            Task T5 = Task.Factory.StartNew(() =>
            {
                Image image = pictureBox1.Image;
                ImageFlip(image);
                pictureBox1.Image = image;
            });
            try
            {
                T5.Wait();
            }
            catch (AggregateException ae)
            {

                Console.WriteLine(ae);
            }
        }
        //implementing   sapia button click event
        private void button10_Click(object sender, EventArgs e)
        {
            if (!fileopen)
            {
                MessageBox.Show("open a picture");
            }
            else
            {


                try
                {


                    Parallel.ForEach(pictureBoxes, p =>
                    {
                        lock (_object)
                        {
                            Image image = p.Image;
                            Bitmap bmpInverted = new Bitmap(image.Width, image.Height);
                            sapia(bmpInverted, image);
                            p.Image = bmpInverted;

                        }

                    });
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
        }
        //implementing   Invert button click event
        private void button11_Click(object sender, EventArgs e)
        {
            if (fileopen)
            {


                Task inver = Task.Factory.StartNew(() =>
                {
                    Image image = pictureBox1.Image;
                    Bitmap bmpInverted = new Bitmap(image.Width, image.Height);
                    Invert(bmpInverted, image);

                    this.pictureBox1.Image = bmpInverted;
                });

                Task inver1 = Task.Factory.StartNew(() =>
                {
                    Image image = pictureBox2.Image;
                    Bitmap bmpInverted = new Bitmap(image.Width, image.Height);
                    Invert(bmpInverted, image);

                    this.pictureBox2.Image = bmpInverted;
                });
                Task inver2 = Task.Factory.StartNew(() =>
                {
                    Image image = pictureBox3.Image;
                    Bitmap bmpInverted = new Bitmap(image.Width, image.Height);
                    Invert(bmpInverted, image);

                    this.pictureBox3.Image = bmpInverted;
                });
                Task inver4 = Task.Factory.StartNew(() =>
                {
                    Image image = pictureBox4.Image;
                    Bitmap bmpInverted = new Bitmap(image.Width, image.Height);
                    Invert(bmpInverted, image);

                    this.pictureBox4.Image = bmpInverted;
                });
            }
            else
            {
                MessageBox.Show("open a picture");
            }

        }
        //implementing   imageflip with rotate button click event
        private void button12_Click(object sender, EventArgs e)
        {

            if (fileopen)
            {
                Parallel.ForEach(pictureBoxes, p =>
                {
                    lock (_object)
                    {
                        Image image = p.Image;
                        ImageFlip(image);
                        p.Image = image;
                    }
                });
                Parallel.ForEach(pictureBoxes, p =>
                {
                    lock (_object)
                    {
                        Image image = p.Image;
                        rotate(image);
                        p.Image = image;
                    }
                });
            }
            else
            {
                MessageBox.Show("open images");
            }
        }
        //implementing   all-filters with rotate button click event
        private void button13_Click(object sender, EventArgs e)
        {

            Task filter1 = Task.Factory.StartNew(() =>
            {
                Image image = pictureBox1.Image;
                Bitmap bmp = new Bitmap(image.Width, image.Height);
                sapia(bmp, image);
                this.pictureBox1.Image = bmp;
            });

            Task filter2 = filter1.ContinueWith((antecedent) =>
            {
                Image image = pictureBox2.Image;
                Bitmap bmp = new Bitmap(image.Width, image.Height);
                grayscale(bmp, image);
                this.pictureBox2.Image = bmp;
            });

            Task filter3 = Task.Factory.StartNew(() =>
            {
                Image image = pictureBox3.Image;
                Bitmap bmp = new Bitmap(image.Width, image.Height);
                Invert(bmp, image);
                this.pictureBox3.Image = bmp;
            });
            Task T2 = filter3.ContinueWith((antecedent) =>
            {

                Image image = pictureBox4.Image;
                Bitmap bmp = new Bitmap(image.Width, image.Height);
                blossome(bmp, image);
                this.pictureBox4.Image = bmp;

            }
            );

            try
            {
                filter1.Wait();
                filter2.Wait();
                filter3.Wait();
            }
            catch (AggregateException ae)
            {

                MessageBox.Show(ae.ToString());
            }
        }
        //implementing   imageflip with gray scale button click event
        private void button14_Click(object sender, EventArgs e)
        {
            if (fileopen)
            {
                Parallel.ForEach(pictureBoxes, p =>
                {
                    lock (_object)
                    {
                        Image image = p.Image;
                        ImageFlip(image);
                        p.Image = image;
                    }
                });
                Parallel.ForEach(pictureBoxes, p =>
                {
                    lock (_object)
                    {
                        Image image = p.Image;
                        Bitmap bmpInverted = new Bitmap(image.Width, image.Height);
                        grayscale(bmpInverted, image);
                        p.Image = bmpInverted;
                    }
                });
            }
            else
            {
                MessageBox.Show("open images");
            }
        }
        //implementing   rotate with sapia scale button click event
        private void button15_Click(object sender, EventArgs e)
        {
            if (fileopen)
            {
                Parallel.ForEach(pictureBoxes, p =>
                {
                    lock (_object)
                    {
                        Image image = p.Image;
                        rotate(image);
                        p.Image = image;
                    }
                });
                Parallel.ForEach(pictureBoxes, p =>
                {
                    lock (_object)
                    {
                        Image image = p.Image;
                        Bitmap bmpInverted = new Bitmap(image.Width, image.Height);
                        sapia(bmpInverted, image);
                        p.Image = bmpInverted;
                    }
                });
            }
            else
            {
                MessageBox.Show("open images");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        //implementing image resizer track bar button click event
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(trackBar1.Value, pictureBox1.Size.Height);
            pictureBox1.Left = (ClientSize.Width - pictureBox1.Width) / 2;
            pictureBox1.Top = (ClientSize.Height | -pictureBox1.Width) / 2;

        }
    }
}

