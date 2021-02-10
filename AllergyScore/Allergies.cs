using System;
using System.Collections.Generic;

namespace AllergyScore
{
    /// <summary>
    /// Encapsulate the information about allergy test score and its analysis.
    /// </summary>
    public class Allergies
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Allergies"/> class.
        /// Initializes the allergies object on base of test score.
        /// </summary>
        /// <param name="score">The allergy test score.</param>
        /// <exception cref="ArgumentException">Thrown when score is less than zero.</exception>
        public Allergies(int score)
        {
            if (score < 0)
            {
                throw new ArgumentException("Thrown when score is less than zero.");
            }

            this.Score = score;
        }

        private int Score { get; set; }

        /// <summary>
        /// Determines on base on the allergy test score for the given person, whether or not they're allergic to a given allergen(s).
        /// </summary>
        /// <param name="allergens">Allergens.</param>
        /// <returns>true if there is an allergy to this allergen, false otherwise.</returns>
        public bool IsAllergicTo(Allergens allergens)
        {
            return Array.Exists(this.AllergensList(), x => x.Equals(allergens));
        }

        /// <summary>
        /// Determines the full list of allergies of the person with given allergy test score.
        /// </summary>
        /// <returns>Full list of allergies of the person with given allergy test score.</returns>
        public Allergens[] AllergensList()
        {
            List<Allergens> list = new List<Allergens>();
            if (this.Score >= (int)Allergens.Cats * 2)
            {
                this.Score %= (int)Allergens.Cats * 2;
            }

            var score = this.Score;
            for (int i = (int)Allergens.Cats; score > 0; i /= 2)
            {
                if (score >= i)
                {
                    list.Add((Allergens)i);
                    score -= i;
                }
            }

            list.Reverse();
            return list.ToArray();
        }
    }
}
