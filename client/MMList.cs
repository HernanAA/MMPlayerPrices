using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MundoManager.Serializer.MM
{
    [XmlRoot("plantelEquipo")]
    public class MMList
    {
        [XmlElement("deporte")]
        public Deporte deporte { get; set; }
        [XmlElement("categoria")]
        public Categoria categoria { get; set; }
        [XmlElement("campeonato")]
        public Campeonato campeonato { get; set; }
        [XmlElement("campeonatoNombreAlternativo")]
        public CampeonatoNombreAlternativo campeonatoNombreAlternativo { get; set; }
        [XmlElement("fechaActual")]
        public FechaActual fechaActual { get; set; }

        [XmlElement("equipo")]
        public Equipo equipo { get; set; }
    }

    public class Deporte
    {
        [XmlAttribute("id")]
        public int id { get; set; }
        [XmlText]
        public string deporteText{ get; set; }
    }

    public class Categoria
    {
        [XmlAttribute("id")]
        public int id { get; set; }
        [XmlAttribute("canal")]
        public string canal { get; set; }
        [XmlText]
        public string categoriaText { get; set; }
    }

    public class Campeonato
    {
        [XmlAttribute("id")]
        public int id { get; set; }
        [XmlText]
        public string campeonatoText { get; set; }
    }

    public class CampeonatoNombreAlternativo
    {
        [XmlAttribute("id")]
        public int id { get; set; }
        [XmlText]
        public string campeonatoNombreAlternativoText { get; set; }
    }

    public class FechaActual
    {
        [XmlText]
        public string fechaActualText { get; set; }
    }

    public class Equipo
    {
        [XmlAttribute("id")]
        public int id { get; set; }
        [XmlAttribute("nombre")]
        public string nombre { get; set; }
        [XmlAttribute("sigla")] // == nombreCorto
        public string sigla { get; set; }
        [XmlAttribute("paisId")]
        public string paisId { get; set; }
        [XmlAttribute("paisNombre")]
        public string paisNombre { get; set; }
        [XmlAttribute("tipo")]
        public string tipo { get; set; }
        [XmlElement("jugadores")]
        public Jugadores jugadores { get; set; }
    }

    public class Jugadores
    {
        [XmlAttribute("cant")]
        public int cant { get; set; }
        [XmlElement("jugador")]
        public List<Jugador> jugadorList { get; set; }
    }

    public class Jugador
    {
        [XmlAttribute("id")]
        public int id { get; set; }
        [XmlElement("nombre")]
        public string nombre { get; set; }
        [XmlElement("apellido")]
        public string apellido { get; set; }

        [XmlElement("ladoHabil")]
        public string ladoHabil { get; set; }
        [XmlElement("fechaNacimiento")]
        public string fechaNacimiento { get; set; }
        [XmlElement("horaNacimiento")]
        public string horaNacimiento { get; set; }
        [XmlElement("edad")]
        public string edad { get; set; }
        [XmlElement("peso")]
        public string peso { get; set; }
        [XmlElement("altura")]
        public string altura { get; set; }
        [XmlElement("apodo")]
        public string apodo { get; set; }

        [XmlElement("rol")]
        public Rol rol { get; set; }
        [XmlElement("camiseta")]
        public string camiseta { get; set; }
        [XmlElement("pais")]
        public Pais pais { get; set; }
        [XmlElement("provincia")]
        public string provincia { get; set; }
        [XmlElement("clubActual")]
        public ClubActual clubActual { get; set; }
        [XmlElement("localidad")]
        public string localidad { get; set; }
        [XmlElement("cotizacion")]
        public string cotizacion { get; set; }
        
    }

    public class Rol
    {
        [XmlAttribute("idRol")]
        public int idRol { get; set; }
        [XmlText]
        public string rolText { get; set; }
    }

    public class Pais
    {
        [XmlAttribute("paisId")]
        public int paisId { get; set; }
        [XmlText]
        public string paisText { get; set; }
    }

    public class ClubActual
    {
        [XmlAttribute("id")]
        public string id { get; set; }
        [XmlAttribute("nombre")]
        public string nombre { get; set; }
        [XmlAttribute("paisId")]
        public string paisId { get; set; }
        [XmlAttribute("paisNombre")]
        public string paisNombre { get; set; }
        [XmlAttribute("paisSigla")]
        public string paisSigla { get; set; }
        [XmlAttribute("tipo")]
        public string tipo { get; set; }
    }
}
