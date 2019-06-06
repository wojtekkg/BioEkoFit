using System;

namespace bio_eko_fit_dto.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException(string msg)
        : base(msg)
        {

        }
    }
}