internal class Car
{
    public int Acceleration;
    public int Deceleration;
    public int MaxSpeed;
    
    public int CurrentSpeed = 0;
    public double TotalDistanceCovered = 0;
    public bool TurnedOn = false;

    public Car(int acceleration, int deceleration, int maxSpeed)
    {
        if (acceleration > 0)
            Acceleration = acceleration;
        else
            throw new ArgumentException("Acceleration must be larger than zero.");

        if (deceleration > 0)
            Deceleration = deceleration;
        else
            throw new ArgumentException("Deceleration must be larger than zero.");

        if ((maxSpeed % deceleration) != 0 || (maxSpeed % acceleration) != 0)
            throw new ArgumentException("Either deceleration or acceleration are not divisors of MaxSpeed.");
        else if (maxSpeed < 0)
            throw new ArgumentException("MaxSpeed must be larger than zero.");
        else
            MaxSpeed = maxSpeed;
    }

    public void Start()
    {
        if (!TurnedOn)
        {
            TurnedOn = true;
            return;
        }
        Console.WriteLine("The car is already turned on.");
    }

    public void TurnOff()
    {
        if (TurnedOn && CurrentSpeed == 0)
        {
            TurnedOn = false;
            return;
        }
        Console.WriteLine("The car could not turn off.");
    }

    public void Accelerate(int seconds)
    {
        if (TurnedOn && seconds >= 0)
        {
            int startingSpeed = CurrentSpeed;

            for (int i = 0; i < seconds; i++) 
            {
                if ((CurrentSpeed + Acceleration) >= MaxSpeed)
                    CurrentSpeed = MaxSpeed;
                else
                    CurrentSpeed += Acceleration;
                this.Drive(startingSpeed);
            }
            return;
        }
        Console.WriteLine("The car is either turned off, or was given a number of seconds it cannot drive.");
    }

    public void Deccelerate(int seconds)
    {
        if (TurnedOn && seconds >= 0)
        {
            int startingSpeed = CurrentSpeed;

            for (int i = 0; i < seconds; i++)
            {
                if ((CurrentSpeed - Deceleration) <= 0)
                    CurrentSpeed = 0;
                else
                    CurrentSpeed -= Deceleration;
                this.Drive(startingSpeed);
            }
            return;
        }
        Console.WriteLine("The car is either turned off, or was given a number of seconds it cannot drive.");
    }

    public void Cruise(int seconds) 
    {
        if (TurnedOn && seconds >= 0)
        {
            for (int i = 0; i < seconds; i++)
                this.Drive();
            return;
        }
        Console.WriteLine("The car is either turned off, or was given a number of seconds it cannot drive.");
    }

    private void Drive()
    {
        TotalDistanceCovered += CurrentSpeed;
    }

    private void Drive(int startingSpeed)
    {
        TotalDistanceCovered += (startingSpeed + ((CurrentSpeed - startingSpeed) / 2));
    }
}