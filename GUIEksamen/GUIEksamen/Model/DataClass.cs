namespace GUIEksamen.Model
{
    public class ImageClass
    {
        public string FileName { get; set; }

        public string ImagePath { get; set; }

        public ImageClass(string name, string path)
        {
            FileName = name;
            ImagePath = path;
        }
    }
}