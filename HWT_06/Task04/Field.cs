namespace Task04
{
    public class Field
    {
        GameObject[,] cell;

        public Field(int w, int h)
        {
            cell = new GameObject[w, h];
        }
    }
}
