using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CursusIndex.business_logic.business_objects;
using CursusIndex.util.validation;
using Tekstenuitleg.business_logic.business_objects;
using umbraco;
using umbraco.NodeFactory;
using umbraco.interfaces;

namespace Tekstenuitleg.usercontrols
{
    public partial class BlogComments : System.Web.UI.UserControl
    {
        private readonly IBlogBo _blogBo = BusinessFactory.GetBlogBo();
        private readonly Dictionary<int, string> _operators = new Dictionary<int, string>();

        public AutomaticSubmissionPrevention SubmissionPrevention;
        public List<INode> Comments;
        public string CurrentUrl;


        public BlogComments()
        {
            _operators.Add(0, "+");
            _operators.Add(1, "-");
            _operators.Add(2, "x");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                FormValidationResult formResult = ValidateCommentForm();
                if (formResult.FormIsValid())
                {
                    SubmitComment();
                    // A stupid way to reset the error messages, but it works
                    ErrorRepeater.DataSource = new List<FieldValidationResult>();
                    ErrorRepeater.DataBind();
                }else
                {
                    ErrorRepeater.DataSource = formResult.GetErronousResults();
                    ErrorRepeater.DataBind();
                    CalcResult.Text = "";
                }

                SubmitPost.Focus();
            }

            SubmissionPrevention = GenerateAutomaticSubmissionPrevention();
            Session.Add("submissionPrevention", SubmissionPrevention);

            Comments = _blogBo.FindComments(Node.GetCurrent());
            CommentsRepeater.DataSource = Comments;
            CommentsRepeater.DataBind();
        }

        private FormValidationResult ValidateCommentForm()
        {
            var formResult = new FormValidationResult();
            FieldValidationResult emailResult = new EmailValidator().Validate(EmailAddress.Text);
            FieldValidationResult nameResult = new NameValidator().Validate(Name.Text);
            FieldValidationResult messageResult = new CommentMessageValidator().Validate(Message.Text);
            FieldValidationResult robotCheck = CheckRobotCheck();

            formResult.AddResult(Name.ID, nameResult);
            formResult.AddResult(EmailAddress.ID, emailResult);
            formResult.AddResult(Message.ID, messageResult);
            formResult.AddResult("AutoSubmissionPreventionLabel", robotCheck);

            return formResult;
        }

        private FieldValidationResult CheckRobotCheck()
        {
            int calcResultInt = -10;
            bool correct = false;
            string message = library.GetDictionaryItem("BlogWrongRobotCheck");
            if (int.TryParse(CalcResult.Text, out calcResultInt))
            {
                if(Session["submissionPrevention"] != null)
                {
                    var prevention = (AutomaticSubmissionPrevention) Session["submissionPrevention"];
                    if(prevention.Result.Equals(calcResultInt))
                    {
                        correct = true;
                        message = "";
                    }
                }
            }

            return new FieldValidationResult(correct, message);
        }

        protected void SubmitComment()
        {
            string name = Name.Text;
            string email = EmailAddress.Text;
            string message = Server.HtmlEncode(Message.Text);
            _blogBo.AddComment(Node.GetCurrent(), name, email, message);
        }

        private AutomaticSubmissionPrevention GenerateAutomaticSubmissionPrevention()
        {
            var random = new Random();
            int number1 = random.Next(1, 10);
            int number2 = random.Next(1, 10);
            int operatorSelector = new Random().Next(0, 3);

            string operatorString = _operators[operatorSelector];
            string calc = "";
            int result = 0;

            if (operatorString.Equals("-") && number2 > number1)
            {

                calc = number2 + " " + operatorString + " " + number1;
                result = number2 - number1;
            }else
            {
                calc = number1 + " " + operatorString + " " + number2;

                if (operatorString.Equals("-"))
                {
                    result = number1 - number2;
                }else if(operatorString.Equals("+"))
                {
                    result = number1 + number2;
                }
                else if (operatorString.Equals("x"))
                {
                    result = number1 * number2;
                }
            }

            return new AutomaticSubmissionPrevention(calc, result);

        }

    }

    public class AutomaticSubmissionPrevention
    {
        public AutomaticSubmissionPrevention(string calc, int result)
        {
            Calculation = calc;
            Result = result;
        }
        public string Calculation;
        public int Result;
    }
}

