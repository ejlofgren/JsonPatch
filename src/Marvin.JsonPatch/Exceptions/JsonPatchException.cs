﻿using Marvin.JsonPatch.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Marvin.JsonPatch.Exceptions
{

    public class JsonPatchException<T> : JsonPatchExceptionBase where T : class
    {
        public Operation<T> FailedOperation { get; private set; }
        public new T AffectedObject { get; private set; }

        private string _message = "";
        public override string Message
        {
            get
            {
                return _message;
            }

        }

        public JsonPatchException()
        {

        }

        public JsonPatchException(Operation<T> operation, string message, T affectedObject)
        {
            FailedOperation = operation;
            _message = message;
            AffectedObject = affectedObject;
        }

        public JsonPatchException(Operation<T> operation, string message, T affectedObject, int statusCode)
            : this(operation, message, affectedObject)
        {
            StatusCode = statusCode;
        }

        public JsonPatchException(Operation<T> operation, string message, T affectedObject,
            int statusCode, Exception innerException)
            : this(operation, message, affectedObject, statusCode)
        {
            InnerException = innerException;
        }
    }
}
