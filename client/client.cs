//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved. 
//----------------------------------------------------------------

using MundoManager.Serializer.Dt;
using MundoManager.Serializer.MM;
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
                JsonSerializer serializer = new JsonSerializer();
                DtList dtList = JsonConvert.DeserializeObject<DtList>(File.ReadAllText("../inputs/jugadores1.json"));

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
                            from jugador in dtList.jugadores.ToList()
                            where
                                (jugador.clubActual.nombreCorto == mmList.equipo.sigla ||
                                mmList.equipo.sigla == "GIM" && jugador.clubActual.nombreCorto == "GLP" ||
                                mmList.equipo.sigla == "ROS" && jugador.clubActual.nombreCorto == "CEN" ||
                                mmList.equipo.sigla == "CHA" && jugador.clubActual.nombreCorto == "CHJ" ||
                                mmList.equipo.sigla == "DEF" && jugador.clubActual.nombreCorto == "DYJ" ||
                                mmList.equipo.sigla == "SMS" && jugador.clubActual.nombreCorto == "SSJ" ||
                                mmList.equipo.sigla == "TAL" && jugador.clubActual.nombreCorto == "TC") &&
                                //jugador.jugador.apellido.Contains(mmJugador.apellido) &&
                                //jugador.jugador.nombres.Contains(mmJugador.nombre)
                                mmJugador.apellido.Contains(jugador.jugador.apellido) &&
                                mmJugador.nombre.Contains(jugador.jugador.nombres)
                            select jugador;

                            if (dtJugador == null || dtJugador.Count() == 0)
                            {
                                unmached++;
                                Console.WriteLine("{2} - {3} Jugador no encontrado: {0} {1} - {4}",
                                    mmJugador.nombre, mmJugador.apellido, unmached, mmList.equipo.sigla, mmFile);
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
    }






}
