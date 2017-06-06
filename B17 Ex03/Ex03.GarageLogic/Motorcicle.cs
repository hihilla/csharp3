
namespace Ex03.GarageLogic
{
    class Motorcicle : Vehicle
    {
        enum e_LicenceType // make sure e_Name is by conventions
        {
            A,
            AB,
            A2,
            B1
        };
        e_LicenceType m_LicenceType;
        int m_EngineVolumCC;

        public Motorcicle()
        {


        }
    }
}
