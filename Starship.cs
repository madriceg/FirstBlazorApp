using System.ComponentModel.DataAnnotations;
using static FirstBlazorApp.ComponentEnums;

namespace FirstBlazorApp
{ 
    public class Starship
    {
        [Required]
        [StringLength(16, ErrorMessage = "Identifier too long (16 character limit).")]
        public string? Identifier { get; set; }

        public string? Description { get; set; }

        [Required]
        public string? Classification { get; set; }

        [Range(1, 100000, ErrorMessage = "Accommodation invalid (1-100000).")]
        public int MaximumAccommodation { get; set; }

        [Required]
        [Range(typeof(bool), "true", "true",
            ErrorMessage = "This form disallows unapproved ships.")]
        public bool IsValidatedDesign { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }

        [Required]
        [Range(typeof(Manufacturer), nameof(Manufacturer.SpaceX),
         nameof(Manufacturer.VirginGalactic), ErrorMessage = "Pick a manufacturer.")]
        public Manufacturer Manufacturer { get; set; } = Manufacturer.Unknown;

        [Required, EnumDataType(typeof(Color))]
        public Color? Color { get; set; } = null;

        [Required, EnumDataType(typeof(Engine))]
        public Engine? Engine { get; set; } = null;
    }

    public class ComponentEnums
    {
        public enum Manufacturer { SpaceX, NASA, ULA, VirginGalactic, Unknown }
        public enum Color { ImperialRed, SpacecruiserGreen, StarshipBlue, VoyagerOrange }
        public enum Engine { Ion, Plasma, Fusion, Warp }
    }
}
