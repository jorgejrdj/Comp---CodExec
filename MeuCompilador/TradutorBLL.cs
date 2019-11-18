using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MeuCompilador
{
    class TradutorBLL
    {
        public static void gravaArquivo()
        {
            FileStream infile, outfile;
            int tam;
            char x;

            infile = new System.IO.FileStream("pontocom.lib",
                                               System.IO.FileMode.Open,
                                               System.IO.FileAccess.Read);
            outfile = new System.IO.FileStream("programa.com",
                                               System.IO.FileMode.Append,
                                               System.IO.FileAccess.Write);

            MeuCompiladorDAL.leIndice();
            tam = int.Parse(IndLib.getTamanho());
            infile.Position = int.Parse(IndLib.getInicio());
            for (int i = 0; i < tam; ++i)
            {
                x = (char)infile.ReadByte();
                outfile.WriteByte((byte)x);
            }
            infile.Close();
            outfile.Close();

        }
        public static void geraExecutavel()
        {
            MeuCompiladorDAL.populaDR();

            MeuCompiladorDAL.leUmTokenValido();
            while (Erro.getErro() == false)
            {
                if (int.Parse(Token.getCodigo()) < 100)
                {
                    gravaArquivo();
                    
                }
                MeuCompiladorDAL.leUmTokenValido();
            }
            Erro.setErro(false);

        }
    }
}
