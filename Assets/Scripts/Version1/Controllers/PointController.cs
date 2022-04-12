namespace Version1.Controllers
{
    public class PointController
    {
        private PointStatus _pointStatus;
        public PointController()
        {
            _pointStatus = PointStatus.None;
        }

        public PointStatus PointStatus => _pointStatus;

        public void SetPointStatus(PointStatus pointStatus)
        {
            _pointStatus = pointStatus;
        }
    }

    public enum PointStatus
    {
        None, 
        Moved,
        Stay
    }
}
