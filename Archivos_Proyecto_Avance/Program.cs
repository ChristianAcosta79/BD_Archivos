using System;
using System.Collections.Generic;
using System.IO;

namespace Archivos_Proyecto_Avance
{
    public unsafe struct Entidad
    {
        public string Nombre;
        public long Direccion;
        public long* dir_atrib;
        public long* dir_datos;
        public long* sig_ent;
    }
    public unsafe struct Archivo
    {
        public string Nombre;
        public FileStream stream;
    }
    public unsafe struct Atributo
    {
        public string Nombre;
        public long Direccion;
        public Char tipo;
        public Int32 tamaño;
        public Int32 tipo_ind;
        public long* dir_ind;
        public long* sig_atrib;
    }
    public unsafe struct Dato
    {
        public long* dato;
        public long Direccion;
        public List<object> campos;
    }
    public unsafe struct Diccionario
    {
        public long cab;
        public Archivo Archivo;
        public List<Entidad> Entidades;
        public List<Atributo> Atributos;
    }
    class Program
    {
        static unsafe void Main(string[] args)
        {
            int op,opt;
            Int64 ant=0;
            long nulo = -1;
            do
            {
                Console.WriteLine("1.-Crear Diccionario");
                Console.WriteLine("2.-Salir");
                op = Convert.ToInt16(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Diccionario nuevo = new Diccionario();
                        Console.WriteLine("Introduce el nombre del diccionario:");
                        nuevo.Archivo.Nombre = Convert.ToString(Console.ReadLine());
                        nuevo.Archivo.stream = new FileStream(nuevo.Archivo.Nombre + " .DD", FileMode.OpenOrCreate, FileAccess.Write);
                        BinaryWriter writer = new BinaryWriter(nuevo.Archivo.stream);
                        nuevo.cab = -1;
                        writer.Write(nuevo.cab);
                        Console.WriteLine("Cabecera");
                        Console.WriteLine(nuevo.cab);
                        do
                        {
                            Console.WriteLine("1.-Alta Entidad");
                            Console.WriteLine("2.-Alta Atributo");
                            Console.WriteLine("3.-Guardar DD");
                            opt = Convert.ToInt16(Console.ReadLine());
                            switch (opt)
                            {
                                case 1:
                                    Entidad nueva = new Entidad();
                                    //nueva.Nombre.Length = 30;
                                    if (nuevo.cab == -1)
                                    {
                                        Console.WriteLine("Ingresa el nombre de la entidad");
                                        nueva.Nombre =  Console.ReadLine();
                                        nueva.Direccion = nuevo.Archivo.stream.Length;
                                        nueva.dir_atrib = &nulo;
                                        nueva.dir_datos = &nulo;
                                        nueva.sig_ent = &nulo;
                                       // nuevo.Entidades.Add(nueva);
                                        writer.Write(nueva.Nombre);
                                        writer.Write(nueva.Direccion);
                                        writer.Write(*nueva.dir_atrib);
                                        writer.Write(*nueva.dir_datos);
                                        writer.Write(*nueva.sig_ent);
                                        Console.WriteLine("Nombre");
                                        Console.WriteLine(nueva.Nombre);
                                        Console.WriteLine("Direccion");
                                        Console.WriteLine(nueva.Direccion);
                                        Console.WriteLine("Dir Atributos");
                                        Console.WriteLine(*nueva.dir_atrib);
                                        Console.WriteLine("Dir Datos");
                                        Console.WriteLine(*nueva.dir_datos);
                                        Console.WriteLine("Dir sig Entidad");
                                        Console.WriteLine(* nueva.sig_ent);
                                        //writer.Write("/n");
                                        nuevo.cab = nueva.Direccion;
                                        //writer.Write(nuevo.cab);
                                        Console.WriteLine("Cabecera");
                                        Console.WriteLine(nuevo.cab);
                                        //Entidad nueva_sig = new Entidad();
                                        // ant = nuevo.cab;
                                    } /*else
                                    {
                                        nueva_sig.Direccion = *(nueva.sig_ent);
                                        if (*(nueva.sig_ent)==-1)
                                        {
                                            int comparison = String.Compare(nueva.Nombre, nueva_sig.Nombre, comparisonType: StringComparison.OrdinalIgnoreCase);
                                            if (comparison > 0)
                                            {
                                                ant = nueva.Direccion;
                                            }
                                            else
                                            {
                                                if (comparison < 0)
                                                {
                                                    nueva.Direccion = ant;
                                                    nueva
                                                }
                                            }

                                        }
                                        

                                        nueva.Direccion = *(nueva.sig_ent);
                                       // Entidad nueva_sig = new Entidad();
                                        //nueva_sig.Direccion = *(nueva.sig_ent);
                                        /*ant = nuevo.cab;
                                        do
                                        {
                                            nueva_sig.Direccion = *(nueva.sig_ent);
                                            int comparison = String.Compare(nueva.Nombre, nueva_sig.Nombre, comparisonType: StringComparison.OrdinalIgnoreCase);
                                            if (comparison > 0)
                                            {
                                                ant = nueva.Direccion;
                                            }else
                                            {
                                                if(comparison < 0)
                                                {
                                                    nueva.Direccion = ant;
                                                    nueva
                                                }
                                            }
                                                

                                    } while (*(nueva.sig_ent) != -1);
                                    }*/
                                break;
                            }
                        } while (opt != 3);
                        writer.Close();
                        nuevo.Archivo.stream.Close();
                        
                        break;

                }
            } while (op != 2);
        }
    }
}
