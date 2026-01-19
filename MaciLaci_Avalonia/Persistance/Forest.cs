using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MaciLaci_Avalonia.Persistance
{
    public class Forest
    {
        private int size;
        private ForestField[,] table;
        public Forest(int size)
        {
            this.Size = size;
            table = new ForestField[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == 0 || j == 0 || j == size - 1 || i == size - 1)
                        Table[i, j] = ForestField.Border;
                    else Table[i, j] = ForestField.Empty;
                }
            }
        }
        public Forest(string filePath)
        {
            Size = Convert.ToInt32(filePath.Split('.')[0].Split('x')[0]);

            table = new ForestField[size, size];
            string[] lines = File.ReadAllLines("Persistance/" + filePath);
            for (int i = 0; i < size; i++)
            {
                string[] parts = lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < size; j++)
                {
                    switch (parts[j])
                    {
                        case "k":
                            table[i, j] = ForestField.Kosar; break;
                        case "m":
                            table[i, j] = ForestField.MaciLaci; break;
                        case "h":
                            table[i, j] = ForestField.Hunter; break;
                        case "u":
                            table[i, j] = ForestField.Empty; break;
                        case "t":
                            table[i, j] = ForestField.Tree; break;
                        case "b":
                            table[i, j] = ForestField.Border; break;
                    }
                }
            }
        }

        public int Size { get => size; set => size = value; }
        public ForestField[,] Table { get => table; set => table = value; }
    }

}
