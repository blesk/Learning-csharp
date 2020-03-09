using System.Collections.Generic;

namespace WSReporter
{
    public class WSLibrary
    {
        private List<License> licenses;

        public string Type { get; set; }
        public string ProductName { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public bool DirectDependency { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public List<License> Licenses { get => licenses; set => licenses = value; }
    }
}