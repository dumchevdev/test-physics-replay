using System;

namespace Game
{
    internal sealed class InputHandlersContainer : IDisposable
    {
        private readonly IInputHandler[] _inputHandlers;

        internal InputHandlersContainer(params IInputHandler[] inputHandlers)
        {
            _inputHandlers = inputHandlers;
        }
        
        public void Dispose()
        {
            foreach (var handler in _inputHandlers)
            {
                handler.Dispose();
            }
        }
    }
}