using System;
using System.Web.Mvc;

namespace WebApp.WebForms
{
    public partial class Stabilization : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Webforms Stabilization";
            if (!IsPostBack)
            {
                ViewState["ConditionIndex"] = 0;
                SetupScreen(0);
                ConditionsType.InnerText = _termsAndConditions[0, 0];
                Conditions.InnerHtml = _termsAndConditions[0, 1];
            }
        }

        private void SetupScreen(int ix)
        {
            ViewState["ConditionIndex"] = ix;
            ConditionsType.InnerText = _termsAndConditions[ix, 0];
            Conditions.InnerHtml = _termsAndConditions[ix, 1];
            Previous.Visible = (ix > 0);
            Next.Visible = (ix < _maxTermsAndConditions);
            AcceptPanel.Visible = (ix == _maxTermsAndConditions);
            Accept.Enabled = AgreeCheckBox.Checked;
        }

        protected void Previous_Click(object sender, EventArgs e)
        {
            var ix = (int) ViewState["ConditionIndex"];
            if (ix > 0)
            {
                ix--;
            }
            SetupScreen(ix);
        }

        protected void Next_Click(object sender, EventArgs e)
        {
            var ix = (int) ViewState["ConditionIndex"];
            if (ix < _maxTermsAndConditions)
            {
                ix++;
            }
            SetupScreen(ix);
        }

        protected void AgreeCheckBox_OnCheckedChanged(object sender, EventArgs e)
        {
            Accept.Enabled = AgreeCheckBox.Checked;
        }

        protected void Accept_Click(object sender, EventArgs e)
        {
            Session["msg"] = "Terms accepted";
            Response.Redirect("/Home/ProtectedContent");
        }

        private static readonly string[,] _termsAndConditions = new string[,]
        {
            {"Tradtional", _conditions1},
            {"Corporate", _conditions2},
            {"Startup", _conditions3},
            {"Cat", _conditions4},
            {"Coffee", _conditions5},
        };

        private const int _maxTermsAndConditions = 4;

        //http://meettheipsums.com/
        //traditional
        private const string _conditions1 =
            @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut eget fringilla ipsum. Mauris turpis risus, convallis molestie cursus ut, bibendum nec erat. In non sapien posuere, ullamcorper nulla vitae, fermentum ipsum. Morbi facilisis convallis neque, vel mattis nisi commodo eu. Etiam est enim, pharetra non tellus at, volutpat condimentum magna. Fusce ac condimentum nulla, non tempor diam. Aliquam dapibus orci et erat semper porta. Donec nec lorem in quam vehicula eleifend. Donec volutpat libero purus, in sagittis mauris euismod eget. Fusce vitae elit nisi. Ut sed felis ac justo mollis interdum. Vivamus eu euismod ex, id dapibus diam. Maecenas et sodales metus, sodales consectetur urna. Phasellus pharetra facilisis ipsum, sit amet maximus metus ultricies a.
<br /><br />
Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nulla sed dignissim turpis, eu cursus felis. Etiam sagittis nisl mattis augue tempor, at dictum ante iaculis. Donec sed erat tortor. Integer facilisis metus libero, vel blandit diam hendrerit et. Ut ex felis, suscipit eu pharetra in, euismod sit amet mi. Nam dapibus est in lorem malesuada viverra. Ut sed nisi et nulla porta eleifend id at leo. Sed vel diam dapibus, laoreet augue in, dictum erat. Fusce semper dictum quam, non aliquam odio rutrum vel.
<br /><br />
Nunc auctor, ipsum non viverra pretium, diam enim fringilla dui, ac gravida lorem nisl et ipsum. Nullam a hendrerit quam, quis dictum felis. Pellentesque auctor eros et risus congue, blandit tincidunt mi blandit. Donec mauris purus, convallis eu dui eget, eleifend laoreet justo. Vivamus accumsan eleifend dui. Nam gravida feugiat eros, eget auctor leo egestas eu. Ut eleifend ut enim blandit auctor. Morbi sodales porttitor nisl, et tristique quam aliquet pharetra. Sed accumsan mattis erat, ut maximus augue ultricies in. Nam ac hendrerit lectus, nec blandit est. Mauris ac orci augue. Suspendisse pharetra turpis at molestie pharetra. Proin consectetur finibus turpis in imperdiet. Nulla varius ante eu congue posuere.";

        //corporate
        private const string _conditions2 =
            @"Collaboratively administrate empowered markets via plug-and-play networks. Dynamically procrastinate B2C users after installed base benefits. Dramatically visualize customer directed convergence without revolutionary ROI.
<br /><br />
Efficiently unleash cross-media information without cross-media value. Quickly maximize timely deliverables for real-time schemas. Dramatically maintain clicks-and-mortar solutions without functional solutions.
<br /><br />
Completely synergize resource sucking relationships via premier niche markets. Professionally cultivate one-to-one customer service with robust ideas. Dynamically innovate resource-leveling customer service for state of the art customer service.";

        //startup
        private const string _conditions3 =
            @"Agile development social media deployment twitter channels business-to-business marketing. Startup hackathon buyer stealth gen-z success equity release. Focus launch party customer metrics scrum project return on investment network effects first mover advantage direct mailing venture stock termsheet handshake. Partnership disruptive direct mailing. Business model canvas iteration business-to-consumer backing infrastructure business plan equity return on investment direct mailing agile development non-disclosure agreement. Assets www.discoverartisans.com conversion creative disruptive churn rate iPad graphical user interface series A financing funding value proposition ownership market. Focus agile development partnership. Infrastructure innovator focus disruptive deployment. Social proof A/B testing ownership twitter first mover advantage research & development. Focus prototype gamification customer partner network churn rate assets seed round infrastructure business model canvas validation.
<br /><br />
Channels beta responsive web design series A financing infrastructure iPad backing twitter monetization partner network interaction design equity seed money stealth. Incubator lean startup market deployment holy grail stealth release twitter buyer client buzz business-to-consumer crowdfunding. Freemium channels branding advisor growth hacking. Value proposition user experience channels social proof android funding stock. Analytics validation long tail monetization first mover advantage startup rockstar user experience handshake backing partnership channels holy grail market. Ownership A/B testing lean startup deployment conversion backing agile development burn rate. Buzz leverage traction research & development ramen incubator infrastructure influencer direct mailing virality network effects stealth beta client. Early adopters crowdsource return on investment buzz. Www.discoverartisans.com direct mailing ecosystem. Influencer user experience market direct mailing business-to-business twitter MVP A/B testing analytics stock infrastructure funding marketing entrepreneur.
<br /><br />
Sales startup user experience launch party. Holy grail graphical user interface startup hypotheses client lean startup focus success gen-z influencer buyer interaction design strategy social proof. Growth hacking funding non-disclosure agreement. Graphical user interface venture agile development alpha strategy responsive web design crowdsource product management success marketing. A/B testing iPad technology channels MVP sales alpha business-to-consumer www.discoverartisans.com startup value proposition learning curve network effects ecosystem. Partner network prototype crowdsource iPhone. IPhone influencer leverage gen-z non-disclosure agreement learning curve early adopters MVP. Founders www.discoverartisans.com lean startup first mover advantage seed round social media growth hacking business-to-business. Freemium buzz value proposition customer non-disclosure agreement interaction design graphical user interface. Disruptive creative A/B testing iteration growth hacking MVP crowdfunding leverage non-disclosure agreement termsheet founders.";

        //cat
        private const string _conditions4 =
            @"Eat grass, throw it back up. Hunt anything that moves meowing non stop for food spot something, big eyes, big eyes, crouch, shake butt, prepare to pounce. Hate dog all of a sudden cat goes crazy intrigued by the shower, for present belly, scratch hand when stroked. Fall over dead (not really but gets sypathy) sleep nap.
<br /><br />
Meow. Knock dish off table head butt cant eat out of my own dish find empty spot in cupboard and sleep all day yet peer out window, chatter at birds, lure them to mouth find something else more interesting. Knock dish off table head butt cant eat out of my own dish. Find something else more interesting fall over dead (not really but gets sypathy) but sleep on keyboard.
<br /><br />
Eat grass, throw it back up hack up furballs spit up on light gray carpet instead of adjacent linoleum or hide head under blanket so no one can see play riveting piece on synthesizer keyboard.";

        //coffee
        private const string _conditions5 =
            @"A percolator eu, ut and sit lungo rich. Galão medium extra, body mocha crema brewed cream grounds. Irish filter wings aged mug, aftertaste latte milk affogato roast.
<br /><br />
Medium ut instant americano carajillo organic cappuccino mazagran plunger pot single shot. Doppio caramelization as fair trade et so trifecta. Single shot black bar rich cup whipped affogato foam.
<br /><br />
Body shop, siphon whipped, mazagran, sit spoon est trifecta extra. So breve barista est, iced grinder cappuccino and ristretto seasonal percolator. Flavour, single shot lungo, steamed iced, espresso barista brewed cinnamon that french press.";

    }
}
