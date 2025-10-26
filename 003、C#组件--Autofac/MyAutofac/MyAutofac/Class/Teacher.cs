namespace MyAutofac
{
    public class Teacher : ITeacher
    {
        [SelectProp]
        public IStudent StudentProp1 { get; set; }

        public IStudent StudentProp2 { get; set; }

        private IStudent StudentCtor1 { get; set; }

        private IStudent StudentCtor2 { get; set; }

        private IStudent StudentMethod1 { get; set; }

        private IStudent StudentMethod2 { get; set; }

        [SelectCtor]
        public Teacher(IStudent student)
        {
            this.StudentCtor1 = student;
        }

        public Teacher(IStudent student1, IStudent student2)
        {
            this.StudentCtor2 = student2;
        }

        [SelectMethod]
        public void SetStudent1(IStudent student)
        {
            this.StudentMethod1 = student;
        }

        public void SetStudent2(IStudent student)
        {
            this.StudentMethod2 = student;
        }
    }
}
