//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved. 
//----------------------------------------------------------------

using MundoManager.Serializer.Dt;
using MundoManager.Serializer.MM;
using MundoManager.Serializer.NF;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace MundoManager.Serializer
{

    class Sample
    {
        static void Main()
        {
            int unmached = 0;

            try
            {
                DtList dtList = JsonConvert.DeserializeObject<DtList>(File.ReadAllText("../inputs/jugadores1.json"));

                NotFounds notFoundsList = JsonConvert.DeserializeObject<NotFounds>(File.ReadAllText("../inputs/notFounds.json"));

                XmlSerializer writer = new XmlSerializer(typeof(MMList));

                XmlSerializer mmSerializer = new XmlSerializer(typeof(MMList));
                string[] mmFiles = Directory.GetFiles("../inputs/", "deportes.futbol.primeraa.plantelxcampeonato.*");

                foreach (string mmFile in mmFiles)
                {
                    using (FileStream fileStream = new FileStream( mmFile, FileMode.Open))
                    {
                        MMList mmList = (MMList)mmSerializer.Deserialize(fileStream);

                        foreach (var mmJugador in mmList.equipo.jugadores.jugadorList)
                        {
                            var dtJugador =
                            from item in dtList.jugadores.ToList()
                            where(
                                    ((item.clubActual.nombreCorto == mmList.equipo.sigla ||
                                    mmList.equipo.sigla == "GIM" && item.clubActual.nombreCorto == "GLP" ||
                                    mmList.equipo.sigla == "ROS" && item.clubActual.nombreCorto == "CEN" ||
                                    mmList.equipo.sigla == "CHA" && item.clubActual.nombreCorto == "CHJ" ||
                                    mmList.equipo.sigla == "DEF" && item.clubActual.nombreCorto == "DYJ" ||
                                    mmList.equipo.sigla == "SMS" && item.clubActual.nombreCorto == "SSJ" ||
                                    mmList.equipo.sigla == "TAL" && item.clubActual.nombreCorto == "TC") &&
                                    //jugador.jugador.apellido.Contains(mmJugador.apellido) &&
                                    //jugador.jugador.nombres.Contains(mmJugador.nombre)
                                    RemoveAccent(mmJugador.apellido).Contains(RemoveAccent(item.jugador.apellido)) &&
                                    RemoveAccent(mmJugador.nombre).Contains(RemoveAccent(item.jugador.nombres)))
                                    ||
                                    (mmJugador.id == 55208 && item.jugador.id == 23469 /*Juan M. Sánchez Miño*/ ||
                                    
                                    mmJugador.id == 55208 && item.jugador.id == 23469 /*Sánchez Miño*/ ||
                                    mmJugador.id == 55208 && item.jugador.id == 23469 /*Sánchez Miño*/ ||
                                    mmJugador.id == 55208 && item.jugador.id == 23469 /*Sánchez Miño*/ ||
                                    mmJugador.id == 55208 && item.jugador.id == 23469 /*Sánchez Miño*/ ||
                                    mmJugador.id == 55208 && item.jugador.id == 23469 /*Sánchez Miño*/ ||
                                    mmJugador.id == 55208 && item.jugador.id == 23469 /*Sánchez Miño*/ ||
                                    mmJugador.id == 55208 && item.jugador.id == 23469 /*Sánchez Miño*/ )

                                )
                            select item;

                            if (dtJugador == null || dtJugador.Count() == 0)
                            {
                                bool inNotFound = FindInNotFounds(notFoundsList, mmJugador.id, mmJugador.nombre, mmJugador.apellido, mmFile.Split('.')[mmFile.Split('.').Length - 2], mmList.equipo.sigla);

                                if (!inNotFound)
                                {
                                    unmached++;
                                    Console.WriteLine("{0} - {1} Jugador no encontrado: {2} {3} - {4}  mmId: {5}",
                                            unmached, mmList.equipo.sigla, mmJugador.nombre, mmJugador.apellido, mmFile.Split('.')[mmFile.Split('.').Length - 2],
                                            mmJugador.id);
                                }
                            }
                            else
                            {
                                mmJugador.cotizacion = dtJugador.First().cotizacion.ToString();
                            }
                        }

                        FileStream outputFile = File.Create("../outputs/" + mmFile.Replace("../inputs/", ""));
                        writer.Serialize(outputFile, mmList);
                        outputFile.Close();
                    }
                }

                Console.WriteLine("Press <ENTER> to terminate the program.");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }


        }

        private static string RemoveAccent(string input)
        {
            return input.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u");
        }

        private static bool FindInNotFounds(NotFounds notFoundsList, int id, string nombre, string apellido, string fileId, string sigla)
        {
            var jugadorNF =
                            from jugador in notFoundsList.jugadores.ToList()
                            where
                                //item.jugador.id == id &&
                                jugador.fileId.ToString() == fileId &&
                                jugador.sigla.ToString() == sigla &&
                                jugador.apellido.Contains(apellido) &&
                                jugador.nombre.Contains(nombre)
                            select jugador;

            if (jugadorNF.Count() > 0) {
                return true;
            }

            return false;
        }
    }






}
