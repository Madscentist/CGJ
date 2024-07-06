namespace Controller.Tools
{
    public class Shield : Tool
    {
        public override void Use(CharacterController controller)
        {
            controller.ShieldOn();
        }
    }
}