using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Bogus.DataSets;
using Xunit;
using static Bogus.DataSets.Name;

namespace MusicTestes.testes
{
    public class MusicsServicesTestes
    {
        private readonly Faker _faker;

        public MusicsServicesTestes()
        {
            _faker = new Faker();
        }

        [Theory]
        [MemberData(nameof(GetMusicsData))]
        public void AddMusic_DeveConcluir_QuandoDadosValidos(Music music)
        {
            // Arrange
            MusicaService sut = new MusicaService();

            // Act & Assert
            sut.AddMusic(music);
        }

        public static IEnumerable<object[]> GetMusicsData()
        {
            var faker = new Faker();

            yield return new object[] { new Music()
                {
                    Nome = faker.Lorem.Word(),
                    Artista = faker.Person.FullName,
                    AnoDeLancamento = faker.Random.Int(1980, 1999),
                    Classificacao = faker.Random.Double(3.2, 5.5),
                    Genero = Genero.Rock
                }
            };
            yield return new object[] { new Music()
                {
                    Nome = faker.Lorem.Word(),
                    Artista = faker.Person.FullName,
                    AnoDeLancamento = faker.Random.Int(1980, 1999),
                    Classificacao = faker.Random.Double(5.5, 8.0),
                    Genero = Genero.RockClassico
                }
            };
        }
    }
}