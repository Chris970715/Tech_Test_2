# Tech_Test_2
Using Collider to open a gate



https://github.com/Chris970715/Tech_Test_2/assets/39882035/27409a0c-cc20-4afb-832c-91e7f757a9cb

![Screenshot 2024-04-11 231135](https://github.com/Chris970715/Tech_Test_2/assets/39882035/5da87235-4acd-4e29-9e41-67518488dc1f)

I added CollitionDectector to detect if Client enters collider where isTrigger is checked. 

So in the code, I make IsOpened to be true if the client enters and IsOpened to be false if the client exists.

    // If the targeted object is in the zone where the isTrigger is checked and the target is Cleint, It will make isOpened true to open door 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Client")
        {
            
            isOpened = true;
            isClosed = false;
        }
    }
    // When client steps out of the area, the door will close.
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Client")
        {
            isOpened = false;
            isClosed = true;
        }
    }
    
In update(), if isopended is true, the door will open. (the speed provided for the door is 100f).
If isClosed is true, the doow will close.
    private void Update()
    {
        if (isOpened)
        {
            float angle = Mathf.MoveTowards(door.transform.eulerAngles.y, 90f, rotationSpeed * Time.deltaTime);
            door.transform.rotation = Quaternion.Euler(0, angle,0);

        }

        if (isClosed)
        {
            float angle = Mathf.MoveTowards(door.transform.eulerAngles.y, 0f, rotationSpeed * Time.deltaTime);
            door.transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }
