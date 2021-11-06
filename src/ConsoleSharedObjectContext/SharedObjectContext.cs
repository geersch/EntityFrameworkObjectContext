using DAL;

namespace ConsoleSharedObjectContext
{
    public class SharedObjectContext
    {
        private readonly WestwindEntities context;
        
        #region Singleton Pattern

        // Static members are lazily initialized.
        // .NET guarantees thread safety for static initialization.
        private static readonly SharedObjectContext instance = new SharedObjectContext();

        // Make the constructor private to hide it. 
        // This class adheres to the singleton pattern.
        private SharedObjectContext()
        {
            // Create the ObjectContext.
            context = new WestwindEntities();
        }

        // Return the single instance of the ClientSessionManager type.
        public static SharedObjectContext Instance
        {
            get
            {
                return instance;
            }
        }   

        #endregion

        public WestwindEntities Context
        {
            get
            {
                return context;
            }
        }
    }
}
