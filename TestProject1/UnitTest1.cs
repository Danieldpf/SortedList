using SortedList;
using System.Collections;

namespace TestProject1
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(5, "Juan")]
        [InlineData(10, "Pepito")]
        [InlineData(6, "Pedro")]
        public void AgregarALaLista(int id, string nombre)
        {
           
            var listaOrdenada = new SortedList<int, Alumno>();


            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            // asignacion de valores a los objetos

            Alumno alumno1 = new Alumno(1,"Juan");
            Alumno alumno2 = new Alumno(2, "Pepito");
            Alumno alumno3 = new Alumno(3, "Renata");


            // Precarga de lista
            listaOrdenada.Add(alumno1.id, alumno1);
            listaOrdenada.Add(alumno2.id, alumno2);
            listaOrdenada.Add(alumno3.id, alumno3);
            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -


            Alumno alumno4 = new Alumno(id, nombre);

            listaOrdenada.Add(id, alumno4);

            Assert.Equal(4, listaOrdenada.Count);
            Assert.Equal("Renata", listaOrdenada[3].nombre);
            Assert.Contains(alumno4, listaOrdenada.Values);     // busca si los valores de la coleccion contienen al alumno en cuestion



        }





        [Fact]
        public void AgregarConEnteroYCadena()
        {
            var listaOrdenada = new SortedList<int, string>();

            listaOrdenada.Add(0, "Juan");
            listaOrdenada.Add(1, "Maria");
            listaOrdenada.Add(2, "Renata");


            Assert.Equal(3, listaOrdenada.Count);
            Assert.Equal("Maria", listaOrdenada[1]);
            Assert.Equal("Juan", listaOrdenada.First().Value);


        }



        [Theory]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(10000)]
        [InlineData(100000)]
        public void AgregarConFor(int cantidad) 
        {
            var listaOrdenada = new SortedList<int, Alumno>();


            for (int i = 1; i <= cantidad; i++)
            {

                listaOrdenada.Add(i, new Alumno(i, $"Alumno {i}"));
            }

            Assert.NotNull(listaOrdenada);
            Assert.Equal(cantidad, listaOrdenada.Count);
            Assert.Equal(cantidad, listaOrdenada.Last().Key);
            Assert.Equal(89, listaOrdenada[89].id);

        }



        [Fact]
        public void Eliminar() 
        {
            var listaOrdenada = new SortedList<int, Alumno>();


            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            //Precarga de la lista
            Alumno a1 = new Alumno(0, "Ana");
            Alumno a2 = new Alumno(1, "Maria");
            Alumno a3 = new Alumno(2, "Juan");
            Alumno a4 = new Alumno(3, "Pedro");


            listaOrdenada.Add(0, a1);
            listaOrdenada.Add(1, a2);
            listaOrdenada.Add(2, a3);
            listaOrdenada.Add(3, a4);
            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            listaOrdenada.Remove(2);

            Assert.False(4 == listaOrdenada.Count);
            Assert.Equal(3, listaOrdenada.Count);
            Assert.False(listaOrdenada.ContainsKey(2));
            
            




        }




        [Fact]
        public void Eliminar100()
        {
            var listaOrdenada = new SortedList<int, Alumno>();


            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            //Precarga de la lista
            for (int i = 1; i <= 150; i++)
            {
                listaOrdenada.Add(i, new Alumno($"Alumno {0}"));
            }
            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            for (int i = 1; i <= 100; i++)
            {
                listaOrdenada.Remove(i);
            }


            Assert.Equal(50, listaOrdenada.Count);
            Assert.Equal(101, listaOrdenada.First().Key);
            Assert.Equal(150, listaOrdenada.Last().Key);
            Assert.False(listaOrdenada.ContainsKey(25));

        }



        [Fact]
        public void ObtenerAlumnosConKeyPar() 
        {
            var listaOrdenada = new SortedList<int, Alumno>();

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            //precarga de la lista
            for (int i = 0; i < 1000; i++)
            {
                listaOrdenada.Add(i, new Alumno(i, $"Alumno {i}"));
            }
            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            var alumnosConKeyPar = from a in listaOrdenada where a.Key % 2 == 0 select a;



            Assert.True(listaOrdenada.Any());
            Assert.Equal(500, alumnosConKeyPar.Count());
            


        }



    }
    
}