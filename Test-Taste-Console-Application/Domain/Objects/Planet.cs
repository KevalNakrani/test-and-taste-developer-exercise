using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Test_Taste_Console_Application.Domain.DataTransferObjects;

namespace Test_Taste_Console_Application.Domain.Objects
{
    public class Planet
    {
        public string Id { get; set; }
        public float SemiMajorAxis { get; set; }
        public ICollection<Moon> Moons { get; set; }
        public float AverageMoonGravity
        {
            get
            {
                if (Moons == null || Moons.Count == 0)
                {
                    return 0.0f; // or whatever default value we prefer when there are no moons
                }

                // Calculate the sum of gravities
                float sum = 0.0f;
                foreach (var moon in Moons)
                {
                    // Calculate gravitational force (gravity) based on MassValue and MassExponent
                    float gravity = CalculateGravity(moon.MassValue, moon.MassExponent);
                    sum += gravity;
                }

                // Calculate the average
                return sum / Moons.Count;
            }
        }

        private float CalculateGravity(float massValue, float massExponent)
        {
            // Calculate gravity based on mass value and exponent
            // We can adjust this calculation based on our specific formula or requirements
            return massValue * (float)Math.Pow(10, massExponent);
        }

        public Planet(PlanetDto planetDto)
        {
            Id = planetDto.Id;
            SemiMajorAxis = planetDto.SemiMajorAxis;
            Moons = new Collection<Moon>();
            if(planetDto.Moons != null)
            {
                foreach (MoonDto moonDto in planetDto.Moons)
                {
                    Moons.Add(new Moon(moonDto));
                }
            }
        }

        public Boolean HasMoons()
        {
            return (Moons != null && Moons.Count > 0);
        }
    }
}
