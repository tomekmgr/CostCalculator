using System.ComponentModel;

namespace CostCalc.DataClass
{
    public class Material
    {
        [ReadOnly(true)]
        public uint Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Material width in millimeters
        /// </summary>
        public uint Width { get; set; }

        /// <summary>
        /// Material height in millimeters
        /// </summary>
        public uint Height { get; set; }

        /// <summary>
        /// Material price
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// Calculated material area
        /// </summary>
        public uint Area
        {
            get
            {
                return this.Width * this.Height;
            }
        }

        /// <summary>
        /// Price for 1 square millimeter
        /// </summary>
        public float PricePerSingleSquareMillimeter
        {
            get
            {
                return this.Price / this.Area;
            }
        }
    }
}
