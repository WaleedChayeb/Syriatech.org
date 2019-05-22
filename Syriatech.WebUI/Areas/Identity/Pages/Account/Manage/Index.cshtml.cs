using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syriatech.Application.Majors;
using Syriatech.Domain.Entities;
using Syriatech.Persistence;

namespace Syriatech.WebUI.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IHostingEnvironment _hostingEnvironment;

        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager, IEmailSender emailSender,
            IHostingEnvironment hostingEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _hostingEnvironment = hostingEnvironment;
        }

        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {

            [Display(Name = "First Name")]
            [Required]
            public string FirstName { get; set; }
            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            [Display(Name = "Gender")]
            [Required]
            public string Gender { get; set; }
            [Display(Name = "Birthday")]
            [DataType(DataType.Date)]
            [Required]
            public DateTime Dob { get; set; }
            [Display(Name = "Country")]
            [Required]
            public string Country { get; set; }
            [Display(Name = "City")]
            [Required]
            public string City { get; set; }
            [Display(Name = "Major")]
            [Required]
            public int Major { get; set; }
            [Display(Name = "Sub Title")]
            [Required]
            public string Title { get; set; }
            [Display(Name = "Years of Experience")]
            [Required]
            public int YearsOfExperience { get; set; }

            [Display(Name = "Skills")]
            [MaxLength(1000)]
            public string Skills { get; set; }

            [Display(Name = "Interests")]
            [MaxLength(1000)]
            public string Interests { get; set; }

            [Display(Name = "Describe your Best Project")]
            [MaxLength(1500)]
            public string BestProject { get; set; }

            [Display(Name = "Bio")]
            [MaxLength(2000)]
            public string Bio { get; set; }
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            public bool Published { get; set; }

        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var userName = await _userManager.GetUserNameAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                Email = email,
                PhoneNumber = phoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                City = user.City,
                Country = user.Country,
                YearsOfExperience = user.YearsOfExperience,
                Major = user.Major,
                Title = user.Title,
                Bio = user.Bio,
                Skills = user.Skills,
                BestProject = user.BestProject,
                Interests = user.Interests,
                Dob = user.Dob,
                Published = user.Published
            };
            if (Input.Dob == DateTime.MinValue)
            {
                Input.Dob = DateTime.Now;
            }
            ViewData["Img"] = user.Picture;
            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);

            GetMajors nm = new GetMajors();
            ViewData["majors"] = nm.All();


            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var email = await _userManager.GetEmailAsync(user);
            if (Input.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
                if (!setEmailResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting email for user with ID '{userId}'.");
                }
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }

            if (Input.FirstName != user.FirstName)
            {
                user.FirstName = Input.FirstName;
            }

            if (Input.LastName != user.LastName)
            {
                user.LastName = Input.LastName;
            }
            if (Input.Dob != user.Dob)
            {
                user.Dob = Input.Dob;
            }

            if (Input.Gender != user.Gender)
            {
                user.Gender = Input.Gender;
            }

            if (Input.City != user.City)
            {
                user.City = Input.City;
            }

            if (Input.Country != user.Country)
            {
                user.Country = Input.Country;
            }

            if (Input.Major != user.Major)
            {
                user.Major = Input.Major;
            }

            if (Input.Title != user.Title)
            {
                user.Title = Input.Title;
            }

            if (Input.YearsOfExperience != user.YearsOfExperience)
            {
                user.YearsOfExperience = Input.YearsOfExperience;
            }

            if (Input.Skills != user.Skills)
            {
                user.Skills = Input.Skills;
            }

            if (Input.Interests != user.Interests)
            {
                user.Interests = Input.Interests;
            }

            if (Input.BestProject != user.BestProject)
            {
                user.BestProject = Input.BestProject;
            }
            if (Input.Bio != user.Bio)
            {
                user.Bio = Input.Bio;
            } 
            var files = HttpContext.Request.Form.Files;
            foreach (var Image in files)
            {
                if (Image != null && Image.Length > 0)
                {
                    Guid newguid = Guid.NewGuid();
                    string phototitle = newguid.ToString();

                    int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB   
                    IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                    var ext = Image.FileName.Substring(Image.FileName.LastIndexOf('.'));
                    var extension = ext.ToLower();
                    if (!AllowedFileExtensions.Contains(extension))
                    {
                        StatusMessage = "Please Upload image of type .jpg,.gif,.png.";
                    }
                    else if (Image.Length > MaxContentLength)
                    {
                        StatusMessage = "Please Upload a file upto 1 mb.";
                    }
                    else
                    {
                        phototitle += extension.ToString();
                        var path = Path.Combine(
                  _hostingEnvironment.WebRootPath, "img",
                  phototitle);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await Image.CopyToAsync(stream);
                            user.Picture = "/img/" + phototitle;

                        }


                    }


                }
            }

            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage += " Your profile has been updated";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }


            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                email,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            StatusMessage = "Verification email sent. Please check your email.";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostPublishAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }


            if (!String.IsNullOrEmpty(Input.FirstName) && !String.IsNullOrEmpty(Input.Bio) && !String.IsNullOrEmpty(Input.Interests) && !String.IsNullOrEmpty(Input.Skills) && !String.IsNullOrEmpty(Input.Title) && Input.Dob != null && !String.IsNullOrEmpty(Input.City))
            {
                if (user.Published == true)
                    user.Published = false;
                else
                    user.Published = true;

                await _userManager.UpdateAsync(user);
                await _signInManager.RefreshSignInAsync(user);
                StatusMessage = "Your profile has been updated";
            }
            else
            {
                StatusMessage = "Make sure to fill all the required data..";
            }

            return RedirectToPage();
        }
    }
}
