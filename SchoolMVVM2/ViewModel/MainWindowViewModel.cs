using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMVVM2.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private List<Model.Section> sectionList;

        public List<Model.Section> SectionList
        {
            get
            {
                return sectionList;
            }
            set
            {
                sectionList = value;
                OnPropertyChanged();
            }
        }

        private Model.Section currentSection;

        public Model.Section CurrentSection
        {
            get
            {
                return currentSection;
            }
            set
            {
                currentSection = value;
                OnPropertyChanged();
            }
        }


        public MainWindowViewModel()
        {
            sectionList = Repository.SectionRepository.GetAll();
            sectionList = sectionList.OrderByDescending(x => x.Level).ThenBy(x => x.Name).ToList();
            CurrentSection = sectionList.First();
        }
    }
}
