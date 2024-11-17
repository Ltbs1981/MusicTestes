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
            Faker faker = new Faker();
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
            yield return new object[] { new Music()
                {
                    Nome = faker.Lorem.Word(),
                    Artista = faker.Person.FullName,
                    AnoDeLancamento = faker.Random.Int(1980, 1999),
                    Classificacao = faker.Random.Double(8.0, 10.0),
                    Genero = Genero.HeavyMetal
                }
            };
        }
        [Fact]
        public void AddMusic_DeveLancarException_QuandoMusicaNula()
        {
            // Arrange
            MusicaService sut = new MusicaService();

            // Act & Assert
            Assert.Throws<Exception>(() => sut.AddMusic(null));
        }
        [Fact]
        public void AddMusic_DeveLancarFormatException_QuandoNomeInvalido()
        {
            // Arrange
            MusicaService sut = new MusicaService();
            var music = new Music()
            {
                Nome = "A",
                Artista = _faker.Person.FullName,
                AnoDeLancamento = 1990,
                Classificacao = 5.0,
                Genero = Genero.Rock
            };

            // Act & Assert
            Assert.Throws<FormatException>(() => sut.AddMusic(music));
        }

        [Fact]
        public void AddMusic_DeveLancarException_QuandoAnoDeLancamentoInvalido()
        {
            // Arrange
            MusicaService sut = new MusicaService();
            var music = new Music()
            {
                Nome = _faker.Lorem.Word(),
                Artista = _faker.Person.FullName,
                AnoDeLancamento = 2020,
                Classificacao = 6.0,
                Genero = Genero.RockClassico
            };

            // Act & Assert
            Assert.Throws<Exception>(() => sut.AddMusic(music));
        }
    }
}