namespace SVS.DP.Patterns.ChainOfResponsibility
{
    public abstract class Handler
    {
        protected Handler _successor;

        public void SetSuccessor(Handler successor)
        {
            _successor = successor;
        }

        public abstract void Process(string file);
    }
}
