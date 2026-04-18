using System.ComponentModel.DataAnnotations;

namespace Fornspar.Data.Db;

public class RemnantType
{
    [Key]
    public int DbId { get; init; }

    /// <summary>
    /// lämningstyp
    /// </summary>
    public required string Identifier { get; init; }
}

/*
Avrättningsplats
Ballastplats
Begravningsplats
Begravningsplats enstaka
Bengömma
Bergshistorisk lämning övrig
Bildristning
Björngrav
Blästbrukslämning
Blästplats
Boplats
Boplatsgrop
Boplatslämning övrig
Boplatsområde
Boplatsvall
Borg
Bro
Brott/täkt
Brunn/kallkälla
Brytningsyta
Bytomt/gårdstomt
Båtlänning
Dammvall
Depåfynd
Dike/ränna
Drag
Fartygs-/båtlämning
Fiskeläge
Flatmarksgrav
Flottningsanläggning
Fornborg
Fornlämningsliknande bildning
Fornlämningsliknande lämning
Fossil åker
Fyndplats
Fyndsamling
Fyr
Fäbod
Färdväg
Färdvägssystem
Fästning/skans
Fångstanläggning övrig
Fångstgrop
Fångstgropssystem
Fångstgård
Förtöjningsanordning
Förvaringsanläggning
Gistgård
Gjuteri
Glasindustri
Grav - uppgift om typ saknas
Grav markerad av sten/block
Grav övrig
Grav- och boplatsområde
Gravfält
Gravhägnad
Gravklot
Gravvård
Gruvhål
Gruvområde
Gränsmärke
Hammare/smedja
Hammarområde
Hamnanläggning
Hamnområde
Hornsamling
Husgrund, förhistorisk/medeltida
Husgrund, historisk tid
Hytt- och hammarområde
Hyttlämning
Hyttområde
Hägnad
Hägnadssystem
Hällmålning
Hällristning
Härd
Hög
Industri övrig
Järnåldersdös
Kalkugn
Kanal
Kanalmärke
Kemisk industri
Kloster
Kokgrop
Kolningsanläggning
Kompassros/väderstreckspil
Kraftindustri
Kvarn
Kyrka/kapell
Kyrkstad
Källa med tradition
Kåta
Labyrint
Livsmedelsindustri
Luftfarkost
Lägenhetsbebyggelse
Metallindustri/järnbruk
Militär anläggning övrig
Militär mötesplats
Minnesmärke
Naturföremål/-bildning med bruk, tradition eller namn
Offerkast
Offerplats
Område med fartygslämningar
Område med flottningsanläggningar
Område med fossil åkermark
Område med militära anläggningar
Område med skogsbrukslämningar
Pappersindustri
Park-/trädgårdsanläggning
Plats med tradition
Rengärda
Renvall
Ristning, medeltid/historisk tid
Runristning
Röjningsröse
Röse
Rösning
Samlingsplats
Sjömärke
Skärvstenshög
Skåre/jaktvärn
Slagfält
Slott/herresäte
Smideslämning
Smidesområde
Småindustriområde
Spärranordning
Stadsbefästning
Stadslager
Stadsvall/stadsmur
Stalotomt
Stenindustri
Stenkammargrav
Stenkistgrav
Stenkrets/stenrad
Stenring
Stenröjd yta
Stensättning
Stenugn
Stridsvärn
Tegelindustri
Terrassering
Textilindustri
Tomtning
Träindustri
Uppfordringsanläggning
Vad
Vallanläggning
Varv/slip
Viste
Vägmärke
Vårdkase
Övrigt
*/