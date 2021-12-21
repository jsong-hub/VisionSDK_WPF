using System.Windows.Forms;
using OpenCvSharp;

namespace VisionSDK_WPF
{
    public class ImageProcessor
    {
        public ImageProcessor()
        {
            
        }

        public Mat RunColorToGrayscale(Mat src)
        {
            Mat dst = new Mat(src.Size(), MatType.CV_8UC1);
            if (src.Channels() == 1)
            {
                MessageBox.Show("Input image is already grayscale.");
            }
            else if(src.Channels() == 3)
            {
                Cv2.CvtColor(src, dst, ColorConversionCodes.BGR2GRAY);
            }
            else
            {
                Cv2.CvtColor(src, dst, ColorConversionCodes.BGRA2GRAY);
            }

            return dst;
        }

        public Mat RunAdaptiveOtsuThreshold(Mat src)
        {
            Mat dst = new Mat();
            Cv2.Threshold(src, dst, 0, 255, ThresholdTypes.Otsu);
            
            return dst;
        }

        public Mat RunHoughCircleDetection(Mat src)
        {
            Mat dst = new Mat();
            Mat gray = new Mat();

            Cv2.CvtColor(src, dst, ColorConversionCodes.RGBA2BGR);

            switch (src.Channels())
            {
                case 1:
                    Cv2.CopyTo(src, gray);
                    break;
                case 3:
                    Cv2.CvtColor(src, gray, ColorConversionCodes.RGB2GRAY);
                    break;
                case 4:
                    Cv2.CvtColor(src, gray, ColorConversionCodes.RGBA2GRAY);
                    break;
            }
            
            var circles = Cv2.HoughCircles(gray, HoughModes.Gradient, 1, 100, 100, 100, 0, 0);
            foreach (var c in circles)
            {
                Point center = new Point(c.Center.X, c.Center.Y);
                Cv2.Circle(dst, center.X, center.Y, (int)c.Radius, Scalar.Red, 5, LineTypes.AntiAlias, 0);
            }

            return dst;
        }

        public void RunThreePointCircle(Mat src)
        {
            Mat dst = new Mat();
            Mat gray = new Mat();

            Cv2.CvtColor(src, dst, ColorConversionCodes.RGBA2BGR);
            
            switch (src.Channels())
            {
                case 1:
                    Cv2.CopyTo(src, gray);
                    break;
                case 3:
                    Cv2.CvtColor(src, gray, ColorConversionCodes.RGB2GRAY);
                    break;
                case 4:
                    Cv2.CvtColor(src, gray, ColorConversionCodes.RGBA2GRAY);
                    break;
            }
            
            
        }
    }
}