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
            TurnedOn = true;
    }

    public void TurnOff()
    {
        if (TurnedOn && CurrentSpeed == 0)
            TurnedOn = false;
    }

    public void Accelerate(int seconds)
    {
        if (seconds <= 0 || !TurnedOn)
            return;

        int startingSpeed = CurrentSpeed;

        if ((CurrentSpeed + (Acceleration * seconds)) >= MaxSpeed)
                CurrentSpeed = MaxSpeed;
        else
                CurrentSpeed += Acceleration * seconds;

        TotalDistanceCovered += (startingSpeed + ((CurrentSpeed - startingSpeed) / 2)) * seconds;
    }

    public void Deccelerate(int seconds)
    {
        if (seconds <= 0 || !TurnedOn)
            return;

        int startingSpeed = CurrentSpeed;

        if ((CurrentSpeed - (Deceleration * seconds)) <= 0)
            CurrentSpeed = 0;
        else
            CurrentSpeed -= Deceleration * seconds;

        TotalDistanceCovered += (startingSpeed + ((CurrentSpeed - startingSpeed) / 2)) * seconds;
    }

    public void Cruise(int seconds) 
    {
        if (TurnedOn)
            TotalDistanceCovered += (seconds * CurrentSpeed);
    }

    private void Drive()
    {

    }
}