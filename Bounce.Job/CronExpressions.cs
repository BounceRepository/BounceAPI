namespace Bounce.Job
{
    public class CronExpressions
    {
        private int _counter;
        private int _hourCounter;
        private int _daysCounter;


        public CronExpressions(int counter)
        {
            _counter = counter;
        }
        public CronExpressions(int hours,int days)
        {
            _daysCounter = days;
            _hourCounter = hours;
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
        public string Days
        {
            get
            {
                return $"0 {_hourCounter} */{_daysCounter} *";
            }
        }

    }
}