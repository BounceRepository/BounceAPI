namespace Bounce.Job
{
    public class CronExpressions
    {
        private int _counter;

        public CronExpressions(int counter)
        {
            _counter = counter;
        }
        public string Minutes {
            get 
            {
                return $"*/{_counter} * * * *"; 
            }
        }
        public string Houres
        {
            get
            {
                return $"0 */{_counter} * * *";
            }
        }
        //public string Days
        //{
        //    get
        //    {
        //        return $"0 */{_counter} * * *";
        //    }
        //}

    }
}