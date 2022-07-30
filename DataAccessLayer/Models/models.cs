using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class ServiceCategories
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public string ImagePath { get; set; }

        [NotMapped]
        public IFormFile image { get; set; }
    }
    
    public class ServiceCategoriesDTO
    {
        public string Title { get; set; }
        public int? Order { get; set; }
        public IFormFile? image { get; set; }
    }

    public class Service 
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        [NotMapped]
        public IFormFile image { get; set; }
        public string Video_URL { get; set; }
        public string Keywords  { get; set; }
        public int Order { get; set; }
        public int Service_Category_ID  { get; set; }

        [ForeignKey("Service_Category_ID")]
        public virtual ServiceCategories ServiceCategories { get; set; }
    }
    
    public class ServiceDTO 
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? image { get; set; }
        public string Video_URL { get; set; }
        public string Keywords  { get; set; }
        public int? Order { get; set; }
        public int? Service_Category_ID  { get; set; }
    }

    public class REQUEST_PROPOSAL
    { 
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int Service_ID { get; set; }

        [ForeignKey("Service_ID")]
        public virtual Service Service { get; set; }
    }
    
    public class REQUEST_PROPOSALDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int? Service_ID { get; set; }
    }
     
    public class Product
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile image { get; set; }
        public string Video_URL { get; set; }
        public string Keywords { get; set; }
        public int YEAR  { get; set; }
        public int Order { get; set; }
    }
    
    public class ProductDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public IFormFile? image { get; set; }
        public string? Video_URL { get; set; }
        public string? Keywords { get; set; }
        public int? YEAR  { get; set; }
        public int? Order { get; set; }
    }

    public class FAQs
    {
        public int ID { get; set; }
        public int Order { get; set; }
        public string  Question  { get; set; }
        public string Answer   { get; set; }
    }
    
    public class FAQsDTO
    {
        public int? Order { get; set; }
        public string  Question  { get; set; }
        public string Answer   { get; set; }
    }
    
    public class KEYWORDS
    {
        public int ID { get; set; }
        public string Title { get; set; }  
    }
    
    public class KEYWORDSDTO
    {
        public string Title { get; set; }  
    }
    
    public class NEWS
    {
        public int ID { get; set; }
        public string Title { get; set; }  
        public string Description { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile image { get; set; }
        public string Keywords { get; set; }
        public int Service_Category_ID { get; set; }

        [ForeignKey("Service_Category_ID")]
        public virtual ServiceCategories ServiceCategories { get; set; }
    }
       
    public class NEWSDTO
    {
        public string Title { get; set; }  
        public string Description { get; set; }
        public IFormFile image { get; set; }
        public string Keywords { get; set; }
        public int? Service_Category_ID { get; set; }
    }
    
    public class EVENTS
    {
        public int ID { get; set; }
        public string Title { get; set; }  
        public string Description { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile image { get; set; }
        public string Keywords { get; set; }
    }
    
    public class EVENTSDTO
    {
        public string Title { get; set; }  
        public string Description { get; set; }
        public IFormFile image { get; set; }
        public string Keywords { get; set; }
    }
    
    public class OUR_TEAM
    {
        public int ID { get; set; }
        public string Name { get; set; }  
        public string Job_Title { get; set; }
        public string PicturePath { get; set; }
        [NotMapped]
        public IFormFile Picture { get; set; }
        public string Department { get; set; }
        public string Bio { get; set; }
        public string Location { get; set; }
    }
    
    public class OUR_TEAMDTO
    {
        public string Name { get; set; }  
        public string Job_Title { get; set; }
        public IFormFile Picture { get; set; }
        public string Department { get; set; }
        public string Bio { get; set; }
        public string Location { get; set; }
    }
     
    public class Portofolio
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile image { get; set; }
        public string ProjectName { get; set; }
        public int Order { get; set; }
        public int Service_Category_ID { get; set; }

        [ForeignKey("Service_Category_ID")]
        public virtual ServiceCategories ServiceCategories { get; set; }
    }
    
    public class PortofolioDTO
    {
        public string? Description { get; set; }
        public IFormFile? image { get; set; }
        public string? ProjectName { get; set; }
        public int? Order { get; set; }
        public int? Service_Category_ID { get; set; }
    }

    public class PortofolioVideo
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string ProjectName { get; set; }
        public string VideoUrl { get; set; } 
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile image { get; set; }
        public int Order { get; set; }
        public int Service_Category_ID { get; set; }

        [ForeignKey("Service_Category_ID")]
        public virtual ServiceCategories ServiceCategories { get; set; }
    }
    
    public class PortofolioVideoDTO
    {
        public string? Description { get; set; }
        public string? ProjectName { get; set; }
        public string? VideoUrl { get; set; }
        public IFormFile? image { get; set; }
        public int? Order { get; set; }
        public int? Service_Category_ID { get; set; }
    }

    public class PortofolioItems
    {
        public int ID { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile image { get; set; }
        public int Order { get; set; } 
        public int Portfolio_ID { get; set; }

        [ForeignKey("Portfolio_ID")]
        public virtual Portofolio Portofolio { get; set; } 
    }
    
    public class PortofolioItemsDTO
    {
        public IFormFile? image { get; set; }
        public int? Order { get; set; }
        public int? Portfolio_ID { get; set; }
    }

    public class Client
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public string Logo { get; set; }

        [NotMapped]
        public IFormFile image { get; set; }

    }
    
    public class ClientDTO
    {
        public string? Title { get; set; }
        public int? Order { get; set; }
        public IFormFile? image { get; set; }
    } 

} 
 