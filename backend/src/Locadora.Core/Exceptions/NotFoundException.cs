namespace Locadora.Core.Exceptions
{
    public class NotFoundException : BussinessException
    {
        public NotFoundException() : base(StatusCodes.NotFound, "Register Not Found!")
        {

        }
    }
}
