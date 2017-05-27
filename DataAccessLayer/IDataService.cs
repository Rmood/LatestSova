using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;


namespace DataAccessLayer
{
    public interface IDataService
    {
        PagedList<Post> GetPosts(ResourceParameters resourceParameters);
        Post GetPost(int id);
        PagedList<Comment> GetComments(ResourceParameters resourceParameters);
        Comment GetComment(int id);
        PagedList<SovaUser> GetSovaUsers(ResourceParameters resourceParameters);
        SovaUser GetSovaUser(int id);
        void CreateSovaUser(SovaUser sovaUser);
        void UpdateSovaUser(SovaUser sovaUser);
        void DeleteSovaUser(SovaUser sovaUser);
        IList<Posttype> GetPosttypes();
        Posttype GetPosttype(int id);
        int GetSovaUserCount();

    }
}
