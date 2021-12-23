namespace CSharpNotları
{
    public class OOP
    {
        #region Propertyİmzaları()

        int yasi;
        string b;
        #region FullProperty
        //[erişimbelirleyici][içeriktipi][propertyadı]
        //{
        //    get { }/* =>Property'den veri istendiğinde tetiklenir.*/
        //    set{ } //=> Propertyİmzaları'e veri gönderildiğinde tetiklenir.
        //    //    Gönderilen veriyi value keywordü ile yakalar.
        //    // Set bloğu tanımlanmazsa readonly, get bloğu tanımlanmazsa writeonly olur
        //}
        public int Yasi
        {
            get { return yasi; }
            set { yasi = value; }
        }

        #endregion
        #endregion
    }
}
