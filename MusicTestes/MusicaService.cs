using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestes
{
    public  class MusicaService
    {
        public void AddMusic(Music music)
        {
            if (music== null)
            {
                throw new Exception("O nome da música não pode ficar em branco");
            }

            if (music.Nome.Length < 2)
            {
                throw new FormatException("Formato incorreto de nome.");
            }

            if (music.AnoDeLancamento>2000 )
            {
                throw new Exception("Por favor, insira músicas com anos abaixo dos anos 2000");
            }

            switch (music.Genero)
            {
                case Genero.Rock:
                    {
                        if (music.Classificacao< 3.2 || music.Classificacao> 5.5)
                            throw new Exception("Talvez seus ouvidos não sejam para esse tipo de música!");
                        break;
                    }
                case Genero.RockClassico:
                    {
                        if (music.Classificacao< 5.5 || music.Classificacao> 8.0)
                            throw new Exception("Parece que você está começando a entender o que é música de verdade!");
                        break;
                    }

                case Genero.HeavyMetal:
                    {
                        if (music.Classificacao< 8.0)
                            throw new Exception("Parece que você está começando a entender o que é música de verdade!");
                        break;
                    }
            }
        }

    }
}
