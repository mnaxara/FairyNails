Ê
[C:\Code\C#\FairyNails\sln\FairyNails\FairyNailsApp\Areas\Identity\IdentityHostingStartup.cs
[		 
assembly		 	
:			 

HostingStartup		 
(		 
typeof		  
(		  !
FairyNailsApp		! .
.		. /
Areas		/ 4
.		4 5
Identity		5 =
.		= >"
IdentityHostingStartup		> T
)		T U
)		U V
]		V W
	namespace

 	
FairyNailsApp


 
.

 
Areas

 
.

 
Identity

 &
{ 
public 

class "
IdentityHostingStartup '
:( )
IHostingStartup* 9
{ 
public 
void 
	Configure 
( 
IWebHostBuilder -
builder. 5
)5 6
{ 	
builder 
. 
ConfigureServices %
(% &
(& '
context' .
,. /
services0 8
)8 9
=>: <
{= >
} 
) 
; 
} 	
} 
} Ú#
hC:\Code\C#\FairyNails\sln\FairyNails\FairyNailsApp\Areas\Identity\Pages\Account\ForgotPassword.cshtml.cs
	namespace 	
FairyNailsApp
 
. 
Areas 
. 
Identity &
.& '
Pages' ,
., -
Account- 4
{ 
[ 
AllowAnonymous 
] 
public 

class 
ForgotPasswordModel $
:% &
	PageModel' 0
{ 
private 
readonly 
UserManager $
<$ %
ApplicationUser% 4
>4 5
_userManager6 B
;B C
private 
readonly 
IEmailSender %
_emailSender& 2
;2 3
public 
ForgotPasswordModel "
(" #
UserManager# .
<. /
ApplicationUser/ >
>> ?
userManager@ K
,K L
IEmailSenderM Y
emailSenderZ e
)e f
{ 	
_userManager 
= 
userManager &
;& '
_emailSender 
= 
emailSender &
;& '
} 	
[ 	
BindProperty	 
] 
public 

InputModel 
Input 
{  !
get" %
;% &
set' *
;* +
}, -
public   
class   

InputModel   
{!! 	
["" 
Required"" 
]"" 
[## 
EmailAddress## 
]## 
public$$ 
string$$ 
Email$$ 
{$$  !
get$$" %
;$$% &
set$$' *
;$$* +
}$$, -
}%% 	
public'' 
async'' 
Task'' 
<'' 
IActionResult'' '
>''' (
OnPostAsync'') 4
(''4 5
)''5 6
{(( 	
if)) 
()) 

ModelState)) 
.)) 
IsValid)) "
)))" #
{** 
var++ 
user++ 
=++ 
await++  
_userManager++! -
.++- .
FindByEmailAsync++. >
(++> ?
Input++? D
.++D E
Email++E J
)++J K
;++K L
if,, 
(,, 
user,, 
==,, 
null,,  
||,,! #
!,,$ %
(,,% &
await,,& +
_userManager,,, 8
.,,8 9!
IsEmailConfirmedAsync,,9 N
(,,N O
user,,O S
),,S T
),,T U
),,U V
{-- 
return// 
RedirectToPage// )
(//) *
$str//* H
)//H I
;//I J
}00 
var44 
code44 
=44 
await44  
_userManager44! -
.44- .+
GeneratePasswordResetTokenAsync44. M
(44M N
user44N R
)44R S
;44S T
code55 
=55 
WebEncoders55 "
.55" #
Base64UrlEncode55# 2
(552 3
Encoding553 ;
.55; <
UTF855< @
.55@ A
GetBytes55A I
(55I J
code55J N
)55N O
)55O P
;55P Q
var66 
callbackUrl66 
=66  !
Url66" %
.66% &
Page66& *
(66* +
$str77 ,
,77, -
pageHandler88 
:88  
null88! %
,88% &
values99 
:99 
new99 
{99  !
area99" &
=99' (
$str99) 3
,993 4
code995 9
}99: ;
,99; <
protocol:: 
::: 
Request:: %
.::% &
Scheme::& ,
)::, -
;::- .
await<< 
_emailSender<< "
.<<" #
SendEmailAsync<<# 1
(<<1 2
Input== 
.== 
Email== 
,==  
$str>> $
,>>$ %
$"?? 3
'Please reset your password by <a href='?? =
{??= >
HtmlEncoder??> I
.??I J
Default??J Q
.??Q R
Encode??R X
(??X Y
callbackUrl??Y d
)??d e
}??e f 
'>clicking here</a>.??f z
"??z {
)??{ |
;??| }
returnAA 
RedirectToPageAA %
(AA% &
$strAA& D
)AAD E
;AAE F
}BB 
returnDD 
PageDD 
(DD 
)DD 
;DD 
}EE 	
}FF 
}GG ÁU
_C:\Code\C#\FairyNails\sln\FairyNails\FairyNailsApp\Areas\Identity\Pages\Account\Login.cshtml.cs
	namespace 	
FairyNailsApp
 
. 
Areas 
. 
Identity &
.& '
Pages' ,
., -
Account- 4
{ 
[ 
AllowAnonymous 
] 
public 

class 

LoginModel 
: 
	PageModel '
{ 
private 
readonly 
UserManager $
<$ %
ApplicationUser% 4
>4 5
_userManager6 B
;B C
private 
readonly 
SignInManager &
<& '
ApplicationUser' 6
>6 7
_signInManager8 F
;F G
private 
readonly 
ILogger  
<  !

LoginModel! +
>+ ,
_logger- 4
;4 5
private 
readonly 
IEmailSender %
_emailSender& 2
;2 3
public 

LoginModel 
( 
SignInManager '
<' (
ApplicationUser( 7
>7 8
signInManager9 F
,F G
ILogger 
< 

LoginModel 
> 
logger  &
,& '
UserManager 
< 
ApplicationUser '
>' (
userManager) 4
,4 5
IEmailSender 
emailSender $
)$ %
{ 	
_userManager 
= 
userManager &
;& '
_signInManager   
=   
signInManager   *
;  * +
_emailSender!! 
=!! 
emailSender!! &
;!!& '
_logger"" 
="" 
logger"" 
;"" 
}## 	
[%% 	
BindProperty%%	 
]%% 
public&& 

InputModel&& 
Input&& 
{&&  !
get&&" %
;&&% &
set&&' *
;&&* +
}&&, -
public(( 
IList(( 
<((  
AuthenticationScheme(( )
>(() *
ExternalLogins((+ 9
{((: ;
get((< ?
;((? @
set((A D
;((D E
}((F G
public** 
string** 
	ReturnUrl** 
{**  !
get**" %
;**% &
set**' *
;*** +
}**, -
[,, 	
TempData,,	 
],, 
public-- 
string-- 
ErrorMessage-- "
{--# $
get--% (
;--( )
set--* -
;--- .
}--/ 0
public// 
class// 

InputModel// 
{00 	
[11 
Required11 
]11 
[22 
EmailAddress22 
]22 
public33 
string33 
Email33 
{33  !
get33" %
;33% &
set33' *
;33* +
}33, -
[55 
Required55 
]55 
[66 
Display66 
(66 
Name66 
=66 
$str66 *
)66* +
]66+ ,
[77 
DataType77 
(77 
DataType77 
.77 
Password77 '
)77' (
]77( )
public88 
string88 
Password88 "
{88# $
get88% (
;88( )
set88* -
;88- .
}88/ 0
[:: 
Display:: 
(:: 
Name:: 
=:: 
$str:: 1
)::1 2
]::2 3
public;; 
bool;; 

RememberMe;; "
{;;# $
get;;% (
;;;( )
set;;* -
;;;- .
};;/ 0
}<< 	
public>> 
async>> 
Task>> 

OnGetAsync>> $
(>>$ %
string>>% +
	returnUrl>>, 5
=>>6 7
null>>8 <
)>>< =
{?? 	
if@@ 
(@@ 
!@@ 
string@@ 
.@@ 
IsNullOrEmpty@@ %
(@@% &
ErrorMessage@@& 2
)@@2 3
)@@3 4
{AA 

ModelStateBB 
.BB 
AddModelErrorBB (
(BB( )
stringBB) /
.BB/ 0
EmptyBB0 5
,BB5 6
ErrorMessageBB7 C
)BBC D
;BBD E
}CC 
	returnUrlEE 
=EE 
	returnUrlEE !
??EE" $
UrlEE% (
.EE( )
ContentEE) 0
(EE0 1
$strEE1 5
)EE5 6
;EE6 7
awaitHH 
HttpContextHH 
.HH 
SignOutAsyncHH *
(HH* +
IdentityConstantsHH+ <
.HH< =
ExternalSchemeHH= K
)HHK L
;HHL M
ExternalLoginsJJ 
=JJ 
(JJ 
awaitJJ #
_signInManagerJJ$ 2
.JJ2 31
%GetExternalAuthenticationSchemesAsyncJJ3 X
(JJX Y
)JJY Z
)JJZ [
.JJ[ \
ToListJJ\ b
(JJb c
)JJc d
;JJd e
	ReturnUrlLL 
=LL 
	returnUrlLL !
;LL! "
}MM 	
publicOO 
asyncOO 
TaskOO 
<OO 
IActionResultOO '
>OO' (
OnPostAsyncOO) 4
(OO4 5
stringOO5 ;
	returnUrlOO< E
=OOF G
nullOOH L
)OOL M
{PP 	
	returnUrlQQ 
=QQ 
	returnUrlQQ !
??QQ" $
UrlQQ% (
.QQ( )
ContentQQ) 0
(QQ0 1
$strQQ1 5
)QQ5 6
;QQ6 7
ifSS 
(SS 

ModelStateSS 
.SS 
IsValidSS "
)SS" #
{TT 
varWW 
resultWW 
=WW 
awaitWW "
_signInManagerWW# 1
.WW1 2
PasswordSignInAsyncWW2 E
(WWE F
InputWWF K
.WWK L
EmailWWL Q
,WWQ R
InputWWS X
.WWX Y
PasswordWWY a
,WWa b
InputWWc h
.WWh i

RememberMeWWi s
,WWs t
lockoutOnFailure	WWu Ö
:
WWÖ Ü
false
WWá å
)
WWå ç
;
WWç é
ifXX 
(XX 
resultXX 
.XX 
	SucceededXX $
)XX$ %
{YY 
_loggerZZ 
.ZZ 
LogInformationZZ *
(ZZ* +
$strZZ+ <
)ZZ< =
;ZZ= >
return[[ 
LocalRedirect[[ (
([[( )
	returnUrl[[) 2
)[[2 3
;[[3 4
}\\ 
if]] 
(]] 
result]] 
.]] 
RequiresTwoFactor]] ,
)]], -
{^^ 
return__ 
RedirectToPage__ )
(__) *
$str__* :
,__: ;
new__< ?
{__@ A
	ReturnUrl__B K
=__L M
	returnUrl__N W
,__W X

RememberMe__Y c
=__d e
Input__f k
.__k l

RememberMe__l v
}__w x
)__x y
;__y z
}`` 
ifaa 
(aa 
resultaa 
.aa 
IsLockedOutaa &
)aa& '
{bb 
_loggercc 
.cc 

LogWarningcc &
(cc& '
$strcc' A
)ccA B
;ccB C
returndd 
RedirectToPagedd )
(dd) *
$strdd* 5
)dd5 6
;dd6 7
}ee 
elseff 
{gg 

ModelStatehh 
.hh 
AddModelErrorhh ,
(hh, -
stringhh- 3
.hh3 4
Emptyhh4 9
,hh9 :
$strhh; S
)hhS T
;hhT U
returnii 
Pageii 
(ii  
)ii  !
;ii! "
}jj 
}kk 
returnnn 
Pagenn 
(nn 
)nn 
;nn 
}oo 	
publicqq 
asyncqq 
Taskqq 
<qq 
IActionResultqq '
>qq' (,
 OnPostSendVerificationEmailAsyncqq) I
(qqI J
)qqJ K
{rr 	
ifss 
(ss 
!ss 

ModelStatess 
.ss 
IsValidss #
)ss# $
{tt 
returnuu 
Pageuu 
(uu 
)uu 
;uu 
}vv 
varxx 
userxx 
=xx 
awaitxx 
_userManagerxx )
.xx) *
FindByEmailAsyncxx* :
(xx: ;
Inputxx; @
.xx@ A
EmailxxA F
)xxF G
;xxG H
ifyy 
(yy 
useryy 
==yy 
nullyy 
)yy 
{zz 

ModelState{{ 
.{{ 
AddModelError{{ (
({{( )
string{{) /
.{{/ 0
Empty{{0 5
,{{5 6
$str{{7 j
){{j k
;{{k l
}|| 
var~~ 
userId~~ 
=~~ 
await~~ 
_userManager~~ +
.~~+ ,
GetUserIdAsync~~, :
(~~: ;
user~~; ?
)~~? @
;~~@ A
var 
code 
= 
await 
_userManager )
.) */
#GenerateEmailConfirmationTokenAsync* M
(M N
userN R
)R S
;S T
var
ÄÄ 
callbackUrl
ÄÄ 
=
ÄÄ 
Url
ÄÄ !
.
ÄÄ! "
Page
ÄÄ" &
(
ÄÄ& '
$str
ÅÅ '
,
ÅÅ' (
pageHandler
ÇÇ 
:
ÇÇ 
null
ÇÇ !
,
ÇÇ! "
values
ÉÉ 
:
ÉÉ 
new
ÉÉ 
{
ÉÉ 
userId
ÉÉ $
=
ÉÉ% &
userId
ÉÉ' -
,
ÉÉ- .
code
ÉÉ/ 3
=
ÉÉ4 5
code
ÉÉ6 :
}
ÉÉ; <
,
ÉÉ< =
protocol
ÑÑ 
:
ÑÑ 
Request
ÑÑ !
.
ÑÑ! "
Scheme
ÑÑ" (
)
ÑÑ( )
;
ÑÑ) *
await
ÖÖ 
_emailSender
ÖÖ 
.
ÖÖ 
SendEmailAsync
ÖÖ -
(
ÖÖ- .
Input
ÜÜ 
.
ÜÜ 
Email
ÜÜ 
,
ÜÜ 
$str
áá $
,
áá$ %
$"
àà 6
(Please confirm your account by <a href='
àà :
{
àà: ;
HtmlEncoder
àà; F
.
ààF G
Default
ààG N
.
ààN O
Encode
ààO U
(
ààU V
callbackUrl
ààV a
)
ààa b
}
ààb c"
'>clicking here</a>.
ààc w
"
ààw x
)
ààx y
;
àày z

ModelState
ää 
.
ää 
AddModelError
ää $
(
ää$ %
string
ää% +
.
ää+ ,
Empty
ää, 1
,
ää1 2
$str
ää3 f
)
ääf g
;
ääg h
return
ãã 
Page
ãã 
(
ãã 
)
ãã 
;
ãã 
}
åå 	
}
çç 
}éé “7
fC:\Code\C#\FairyNails\sln\FairyNails\FairyNailsApp\Areas\Identity\Pages\Account\Manage\Index.cshtml.cs
	namespace 	
FairyNailsApp
 
. 
Areas 
. 
Identity &
.& '
Pages' ,
., -
Account- 4
.4 5
Manage5 ;
{ 
public 

partial 
class 

IndexModel #
:$ %
	PageModel& /
{ 
private 
readonly 
UserManager $
<$ %
ApplicationUser% 4
>4 5
_userManager6 B
;B C
private 
readonly 
SignInManager &
<& '
ApplicationUser' 6
>6 7
_signInManager8 F
;F G
public 

IndexModel 
( 
UserManager 
< 
ApplicationUser '
>' (
userManager) 4
,4 5
SignInManager 
< 
ApplicationUser )
>) *
signInManager+ 8
)8 9
{ 	
_userManager 
= 
userManager &
;& '
_signInManager 
= 
signInManager *
;* +
} 	
public 
string 
Username 
{  
get! $
;$ %
set& )
;) *
}+ ,
[ 	
TempData	 
] 
public 
string 
StatusMessage #
{$ %
get& )
;) *
set+ .
;. /
}0 1
[ 	
BindProperty	 
] 
public   

InputModel   
Input   
{    !
get  " %
;  % &
set  ' *
;  * +
}  , -
public"" 
class"" 

InputModel"" 
{## 	
[$$ 
Phone$$ 
]$$ 
[%% 
Display%% 
(%% 
Name%% 
=%% 
$str%% *
)%%* +
]%%+ ,
public&& 
string&& 
PhoneNumber&& %
{&&& '
get&&( +
;&&+ ,
set&&- 0
;&&0 1
}&&2 3
}'' 	
private)) 
async)) 
Task)) 
	LoadAsync)) $
())$ %
ApplicationUser))% 4
user))5 9
)))9 :
{** 	
var++ 
userName++ 
=++ 
await++  
_userManager++! -
.++- .
GetUserNameAsync++. >
(++> ?
user++? C
)++C D
;++D E
var,, 
phoneNumber,, 
=,, 
await,, #
_userManager,,$ 0
.,,0 1
GetPhoneNumberAsync,,1 D
(,,D E
user,,E I
),,I J
;,,J K
Username.. 
=.. 
userName.. 
;..  
Input00 
=00 
new00 

InputModel00 "
{11 
PhoneNumber22 
=22 
phoneNumber22 )
}33 
;33 
}44 	
public66 
async66 
Task66 
<66 
IActionResult66 '
>66' (

OnGetAsync66) 3
(663 4
)664 5
{77 	
var88 
user88 
=88 
await88 
_userManager88 )
.88) *
GetUserAsync88* 6
(886 7
User887 ;
)88; <
;88< =
if99 
(99 
user99 
==99 
null99 
)99 
{:: 
return;; 
NotFound;; 
(;;  
$";;  ")
Unable to load user with ID ';;" ?
{;;? @
_userManager;;@ L
.;;L M
	GetUserId;;M V
(;;V W
User;;W [
);;[ \
};;\ ]
'.;;] _
";;_ `
);;` a
;;;a b
}<< 
await>> 
	LoadAsync>> 
(>> 
user>>  
)>>  !
;>>! "
return?? 
Page?? 
(?? 
)?? 
;?? 
}@@ 	
publicBB 
asyncBB 
TaskBB 
<BB 
IActionResultBB '
>BB' (
OnPostAsyncBB) 4
(BB4 5
)BB5 6
{CC 	
varDD 
userDD 
=DD 
awaitDD 
_userManagerDD )
.DD) *
GetUserAsyncDD* 6
(DD6 7
UserDD7 ;
)DD; <
;DD< =
ifEE 
(EE 
userEE 
==EE 
nullEE 
)EE 
{FF 
returnGG 
NotFoundGG 
(GG  
$"GG  ")
Unable to load user with ID 'GG" ?
{GG? @
_userManagerGG@ L
.GGL M
	GetUserIdGGM V
(GGV W
UserGGW [
)GG[ \
}GG\ ]
'.GG] _
"GG_ `
)GG` a
;GGa b
}HH 
ifJJ 
(JJ 
!JJ 

ModelStateJJ 
.JJ 
IsValidJJ #
)JJ# $
{KK 
awaitLL 
	LoadAsyncLL 
(LL  
userLL  $
)LL$ %
;LL% &
returnMM 
PageMM 
(MM 
)MM 
;MM 
}NN 
varPP 
phoneNumberPP 
=PP 
awaitPP #
_userManagerPP$ 0
.PP0 1
GetPhoneNumberAsyncPP1 D
(PPD E
userPPE I
)PPI J
;PPJ K
ifQQ 
(QQ 
InputQQ 
.QQ 
PhoneNumberQQ !
!=QQ" $
phoneNumberQQ% 0
)QQ0 1
{RR 
varSS 
setPhoneResultSS "
=SS# $
awaitSS% *
_userManagerSS+ 7
.SS7 8
SetPhoneNumberAsyncSS8 K
(SSK L
userSSL P
,SSP Q
InputSSR W
.SSW X
PhoneNumberSSX c
)SSc d
;SSd e
ifTT 
(TT 
!TT 
setPhoneResultTT #
.TT# $
	SucceededTT$ -
)TT- .
{UU 
varVV 
userIdVV 
=VV  
awaitVV! &
_userManagerVV' 3
.VV3 4
GetUserIdAsyncVV4 B
(VVB C
userVVC G
)VVG H
;VVH I
throwWW 
newWW %
InvalidOperationExceptionWW 7
(WW7 8
$"WW8 :M
AUnexpected error occurred setting phone number for user with ID 'WW: {
{WW{ |
userId	WW| Ç
}
WWÇ É
'.
WWÉ Ö
"
WWÖ Ü
)
WWÜ á
;
WWá à
}XX 
}YY 
await[[ 
_signInManager[[  
.[[  !
RefreshSignInAsync[[! 3
([[3 4
user[[4 8
)[[8 9
;[[9 :
StatusMessage\\ 
=\\ 
$str\\ ;
;\\; <
return]] 
RedirectToPage]] !
(]]! "
)]]" #
;]]# $
}^^ 	
}__ 
}`` ˛!
hC:\Code\C#\FairyNails\sln\FairyNails\FairyNailsApp\Areas\Identity\Pages\Account\Manage\ManageNavPages.cs
	namespace 	
FairyNailsApp
 
. 
Areas 
. 
Identity &
.& '
Pages' ,
., -
Account- 4
.4 5
Manage5 ;
{ 
public		 

static		 
class		 
ManageNavPages		 &
{

 
public 
static 
string 
Index "
=># %
$str& -
;- .
public 
static 
string 
Email "
=># %
$str& -
;- .
public 
static 
string 
ChangePassword +
=>, .
$str/ ?
;? @
public 
static 
string 
ExternalLogins +
=>, .
$str/ ?
;? @
public 
static 
string 
PersonalData )
=>* ,
$str- ;
;; <
public 
static 
string #
TwoFactorAuthentication 4
=>5 7
$str8 Q
;Q R
public 
static 
string 
IndexNavClass *
(* +
ViewContext+ 6
viewContext7 B
)B C
=>D F
PageNavClassG S
(S T
viewContextT _
,_ `
Indexa f
)f g
;g h
public 
static 
string 
EmailNavClass *
(* +
ViewContext+ 6
viewContext7 B
)B C
=>D F
PageNavClassG S
(S T
viewContextT _
,_ `
Emaila f
)f g
;g h
public 
static 
string "
ChangePasswordNavClass 3
(3 4
ViewContext4 ?
viewContext@ K
)K L
=>M O
PageNavClassP \
(\ ]
viewContext] h
,h i
ChangePasswordj x
)x y
;y z
public 
static 
string "
ExternalLoginsNavClass 3
(3 4
ViewContext4 ?
viewContext@ K
)K L
=>M O
PageNavClassP \
(\ ]
viewContext] h
,h i
ExternalLoginsj x
)x y
;y z
public 
static 
string  
PersonalDataNavClass 1
(1 2
ViewContext2 =
viewContext> I
)I J
=>K M
PageNavClassN Z
(Z [
viewContext[ f
,f g
PersonalDatah t
)t u
;u v
public!! 
static!! 
string!! +
TwoFactorAuthenticationNavClass!! <
(!!< =
ViewContext!!= H
viewContext!!I T
)!!T U
=>!!V X
PageNavClass!!Y e
(!!e f
viewContext!!f q
,!!q r$
TwoFactorAuthentication	!!s ä
)
!!ä ã
;
!!ã å
private## 
static## 
string## 
PageNavClass## *
(##* +
ViewContext##+ 6
viewContext##7 B
,##B C
string##D J
page##K O
)##O P
{$$ 	
var%% 

activePage%% 
=%% 
viewContext%% (
.%%( )
ViewData%%) 1
[%%1 2
$str%%2 >
]%%> ?
as%%@ B
string%%C I
??&& 
System&& 
.&& 
IO&& 
.&& 
Path&& !
.&&! "'
GetFileNameWithoutExtension&&" =
(&&= >
viewContext&&> I
.&&I J
ActionDescriptor&&J Z
.&&Z [
DisplayName&&[ f
)&&f g
;&&g h
return'' 
string'' 
.'' 
Equals''  
(''  !

activePage''! +
,''+ ,
page''- 1
,''1 2
StringComparison''3 C
.''C D
OrdinalIgnoreCase''D U
)''U V
?''W X
$str''Y a
:''b c
null''d h
;''h i
}(( 	
})) 
}** ÈS
bC:\Code\C#\FairyNails\sln\FairyNails\FairyNailsApp\Areas\Identity\Pages\Account\Register.cshtml.cs
	namespace 	
FairyNailsApp
 
. 
Areas 
. 
Identity &
.& '
Pages' ,
., -
Account- 4
{ 
[ 
AllowAnonymous 
] 
public 

class 
RegisterModel 
:  
	PageModel! *
{ 
private 
readonly 
SignInManager &
<& '
ApplicationUser' 6
>6 7
_signInManager8 F
;F G
private 
readonly 
UserManager $
<$ %
ApplicationUser% 4
>4 5
_userManager6 B
;B C
private 
readonly 
ILogger  
<  !
RegisterModel! .
>. /
_logger0 7
;7 8
private 
readonly 
IEmailSender %
_emailSender& 2
;2 3
public 
RegisterModel 
( 
UserManager 
< 
ApplicationUser '
>' (
userManager) 4
,4 5
SignInManager 
< 
ApplicationUser )
>) *
signInManager+ 8
,8 9
ILogger 
< 
RegisterModel !
>! "
logger# )
,) *
IEmailSender   
emailSender   $
)  $ %
{!! 	
_userManager"" 
="" 
userManager"" &
;""& '
_signInManager## 
=## 
signInManager## *
;##* +
_logger$$ 
=$$ 
logger$$ 
;$$ 
_emailSender%% 
=%% 
emailSender%% &
;%%& '
}&& 	
[(( 	
BindProperty((	 
](( 
public)) 

InputModel)) 
Input)) 
{))  !
get))" %
;))% &
set))' *
;))* +
})), -
public++ 
string++ 
	ReturnUrl++ 
{++  !
get++" %
;++% &
set++' *
;++* +
}++, -
public-- 
IList-- 
<--  
AuthenticationScheme-- )
>--) *
ExternalLogins--+ 9
{--: ;
get--< ?
;--? @
set--A D
;--D E
}--F G
public// 
class// 

InputModel// 
{00 	
[11 
Required11 
]11 
[22 
Display22 
(22 
Name22 
=22 
$str22 !
)22! "
]22" #
public33 
string33 
Name33 
{33  
get33! $
;33$ %
set33& )
;33) *
}33+ ,
[55 
Required55 
]55 
[66 
Display66 
(66 
Name66 
=66 
$str66 $
)66$ %
]66% &
public77 
string77 
	FirstName77 #
{77$ %
get77& )
;77) *
set77+ .
;77. /
}770 1
[99 
Required99 
]99 
[:: 
EmailAddress:: 
]:: 
[;; 
Display;; 
(;; 
Name;; 
=;; 
$str;; #
);;# $
];;$ %
public<< 
string<< 
Email<< 
{<<  !
get<<" %
;<<% &
set<<' *
;<<* +
}<<, -
[>> 
Required>> 
]>> 
[?? 
StringLength?? 
(?? 
$num?? 
,?? 
ErrorMessage?? +
=??, -
$str??. l
,??l m
MinimumLength??n {
=??| }
$num??~ 
)	?? Ä
]
??Ä Å
[@@ 
DataType@@ 
(@@ 
DataType@@ 
.@@ 
Password@@ '
)@@' (
]@@( )
[AA 
DisplayAA 
(AA 
NameAA 
=AA 
$strAA *
)AA* +
]AA+ ,
publicBB 
stringBB 
PasswordBB "
{BB# $
getBB% (
;BB( )
setBB* -
;BB- .
}BB/ 0
[DD 
DataTypeDD 
(DD 
DataTypeDD 
.DD 
PasswordDD '
)DD' (
]DD( )
[EE 
DisplayEE 
(EE 
NameEE 
=EE 
$strEE 4
)EE4 5
]EE5 6
[FF 
CompareFF 
(FF 
$strFF 
,FF  
ErrorMessageFF! -
=FF. /
$strFF0 f
)FFf g
]FFg h
publicGG 
stringGG 
ConfirmPasswordGG )
{GG* +
getGG, /
;GG/ 0
setGG1 4
;GG4 5
}GG6 7
}HH 	
publicJJ 
asyncJJ 
TaskJJ 

OnGetAsyncJJ $
(JJ$ %
stringJJ% +
	returnUrlJJ, 5
=JJ6 7
nullJJ8 <
)JJ< =
{KK 	
	ReturnUrlLL 
=LL 
	returnUrlLL !
;LL! "
ExternalLoginsMM 
=MM 
(MM 
awaitMM #
_signInManagerMM$ 2
.MM2 31
%GetExternalAuthenticationSchemesAsyncMM3 X
(MMX Y
)MMY Z
)MMZ [
.MM[ \
ToListMM\ b
(MMb c
)MMc d
;MMd e
}NN 	
publicPP 
asyncPP 
TaskPP 
<PP 
IActionResultPP '
>PP' (
OnPostAsyncPP) 4
(PP4 5
stringPP5 ;
	returnUrlPP< E
=PPF G
nullPPH L
)PPL M
{QQ 	
	returnUrlRR 
=RR 
	returnUrlRR !
??RR" $
UrlRR% (
.RR( )
ContentRR) 0
(RR0 1
$strRR1 5
)RR5 6
;RR6 7
ExternalLoginsSS 
=SS 
(SS 
awaitSS #
_signInManagerSS$ 2
.SS2 31
%GetExternalAuthenticationSchemesAsyncSS3 X
(SSX Y
)SSY Z
)SSZ [
.SS[ \
ToListSS\ b
(SSb c
)SSc d
;SSd e
ifTT 
(TT 

ModelStateTT 
.TT 
IsValidTT "
)TT" #
{UU 
varVV 
userVV 
=VV 
newVV 
ApplicationUserVV .
{VV/ 0
NameVV1 5
=VV6 7
InputVV8 =
.VV= >
NameVV> B
,VVB C
	FirstNameVVD M
=VVN O
InputVVP U
.VVU V
	FirstNameVVV _
,VV_ `
UserNameVVa i
=VVj k
InputVVl q
.VVq r
EmailVVr w
,VVw x
EmailVVy ~
=	VV Ä
Input
VVÅ Ü
.
VVÜ á
Email
VVá å
}
VVå ç
;
VVç é
varWW 
resultWW 
=WW 
awaitWW "
_userManagerWW# /
.WW/ 0
CreateAsyncWW0 ;
(WW; <
userWW< @
,WW@ A
InputWWB G
.WWG H
PasswordWWH P
)WWP Q
;WWQ R
ifXX 
(XX 
resultXX 
.XX 
	SucceededXX $
)XX$ %
{YY 
_loggerZZ 
.ZZ 
LogInformationZZ *
(ZZ* +
$strZZ+ V
)ZZV W
;ZZW X
var\\ 
code\\ 
=\\ 
await\\ $
_userManager\\% 1
.\\1 2/
#GenerateEmailConfirmationTokenAsync\\2 U
(\\U V
user\\V Z
)\\Z [
;\\[ \
code]] 
=]] 
WebEncoders]] &
.]]& '
Base64UrlEncode]]' 6
(]]6 7
Encoding]]7 ?
.]]? @
UTF8]]@ D
.]]D E
GetBytes]]E M
(]]M N
code]]N R
)]]R S
)]]S T
;]]T U
var^^ 
callbackUrl^^ #
=^^$ %
Url^^& )
.^^) *
Page^^* .
(^^. /
$str__ /
,__/ 0
pageHandler`` #
:``# $
null``% )
,``) *
valuesaa 
:aa 
newaa  #
{aa$ %
areaaa& *
=aa+ ,
$straa- 7
,aa7 8
userIdaa9 ?
=aa@ A
useraaB F
.aaF G
IdaaG I
,aaI J
codeaaK O
=aaP Q
codeaaR V
}aaW X
,aaX Y
protocolbb  
:bb  !
Requestbb" )
.bb) *
Schemebb* 0
)bb0 1
;bb1 2
awaitdd 
_emailSenderdd &
.dd& '
SendEmailAsyncdd' 5
(dd5 6
Inputdd6 ;
.dd; <
Emaildd< A
,ddA B
$strddC W
,ddW X
$"ee 4
(Please confirm your account by <a href='ee B
{eeB C
HtmlEncodereeC N
.eeN O
DefaulteeO V
.eeV W
EncodeeeW ]
(ee] ^
callbackUrlee^ i
)eei j
}eej k 
'>clicking here</a>.eek 
"	ee Ä
)
eeÄ Å
;
eeÅ Ç
ifgg 
(gg 
_userManagergg $
.gg$ %
Optionsgg% ,
.gg, -
SignIngg- 3
.gg3 4#
RequireConfirmedAccountgg4 K
)ggK L
{hh 
returnii 
RedirectToPageii -
(ii- .
$strii. D
,iiD E
newiiF I
{iiJ K
emailiiL Q
=iiR S
InputiiT Y
.iiY Z
EmailiiZ _
}ii` a
)iia b
;iib c
}jj 
elsekk 
{ll 
awaitmm 
_signInManagermm ,
.mm, -
SignInAsyncmm- 8
(mm8 9
usermm9 =
,mm= >
isPersistentmm? K
:mmK L
falsemmM R
)mmR S
;mmS T
returnnn 
LocalRedirectnn ,
(nn, -
	returnUrlnn- 6
)nn6 7
;nn7 8
}oo 
}pp 
foreachqq 
(qq 
varqq 
errorqq "
inqq# %
resultqq& ,
.qq, -
Errorsqq- 3
)qq3 4
{rr 

ModelStatess 
.ss 
AddModelErrorss ,
(ss, -
stringss- 3
.ss3 4
Emptyss4 9
,ss9 :
errorss; @
.ss@ A
DescriptionssA L
)ssL M
;ssM N
}tt 
}uu 
returnxx 
Pagexx 
(xx 
)xx 
;xx 
}yy 	
}zz 
}{{ »
QC:\Code\C#\FairyNails\sln\FairyNails\FairyNailsApp\Controllers\AdminController.cs
	namespace 	
FairyNailsApp
 
. 
Controllers #
{ 
public 

class 
AdminController  
:! "

Controller# -
{ 
private 
readonly 
RoleManager $
<$ %
IdentityRole% 1
>1 2
_rolemanager3 ?
;? @
private 
readonly 
IPrestationService +
_prestationService, >
;> ?
public 
AdminController 
( 
RoleManager *
<* +
IdentityRole+ 7
>7 8
rolemanager9 D
,D E
IPrestationServiceF X
prestationServiceY j
)j k
{ 	
this 
. 
_rolemanager 
= 
rolemanager  +
;+ ,
this 
. 
_prestationService #
=$ %
prestationService& 7
;7 8
} 	
public 
IActionResult 
Index "
(" #
)# $
{ 	
return 
View 
( 
) 
; 
} 	
[ 	
HttpPost	 
] 
[ 	$
ValidateAntiForgeryToken	 !
]! "
public 
IActionResult 
UpdatePrestation -
(- .$
AdminPrestationViewModel. F

prestationG Q
)Q R
{   	
_prestationService!! 
.!! 
UpdatePrestation!! /
<!!/ 0$
AdminPrestationViewModel!!0 H
>!!H I
(!!I J

prestation!!J T
)!!T U
;!!U V
return## 
RedirectToAction## #
(### $
$str##$ +
)##+ ,
;##, -
}$$ 	
[&& 	
HttpPost&&	 
]&& 
['' 	$
ValidateAntiForgeryToken''	 !
]''! "
public(( 
IActionResult(( 
DeletePrestation(( -
(((- .
Int32((. 3
idPrestation((4 @
)((@ A
{)) 	
_prestationService** 
.** 
DeletePrestation** /
(**/ 0
idPrestation**0 <
)**< =
;**= >
return,, 
RedirectToAction,, #
(,,# $
$str,,$ +
),,+ ,
;,,, -
}-- 	
[// 	
HttpPost//	 
]// 
[00 	$
ValidateAntiForgeryToken00	 !
]00! "
public11 
IActionResult11 
AddPrestation11 *
(11* +$
AdminPrestationViewModel11+ C

prestation11D N
)11N O
{22 	
_prestationService33 
.33 
AddPrestation33 ,
(33, -

prestation33- 7
)337 8
;338 9
return44 
RedirectToAction44 #
(44# $
$str44$ +
)44+ ,
;44, -
}55 	
}66 
}77 €4
PC:\Code\C#\FairyNails\sln\FairyNails\FairyNailsApp\Controllers\AjaxController.cs
	namespace 	
FairyNailsApp
 
. 
Controllers #
{ 
public 

class 
AjaxController 
:  !

Controller" ,
{ 
private 
readonly 
IRendezVousService +
_rendezVousService, >
;> ?
private 
readonly 
IPrestationService +
_prestationService, >
;> ?
public 
AjaxController 
( 
IRendezVousService 0
rendezVousService1 B
,B C
IPrestationServiceD V
prestationServiceW h
)h i
{ 	
this 
. 
_rendezVousService #
=$ %
rendezVousService& 7
;7 8
this 
. 
_prestationService #
=$ %
prestationService& 7
;7 8
} 	
[ 	
HttpPost	 
] 
public 
IActionResult 
CalendarChangeMonth 0
(0 1
Int321 6
month7 <
,< =
Int32> C
yearD H
)H I
{ 	
CalendarViewModel 

rendezVous (
=) *
new+ .
CalendarViewModel/ @
(@ A
)A B
{ 
UnavaibleTimeCode !
=" #
_rendezVousService$ 6
.6 7"
GetUnavailableDateCode7 M
(M N
monthN S
)S T
,T U
FirstDayOfMonth 
=  !
new" %
DateTime& .
(. /
year/ 3
,3 4
month5 :
,: ;
$num< =
)= >
} 
; 
return!! 
PartialView!! 
(!! 

rendezVous!! )
)!!) *
;!!* +
}"" 	
[$$ 	
HttpPost$$	 
]$$ 
public%% 
IActionResult%% #
GetRendezVousManagement%% 4
(%%4 5
)%%5 6
{&& 	.
"AdminRendezVousManagementViewModel'' .
model''/ 4
=''5 6
new''7 :.
"AdminRendezVousManagementViewModel''; ]
(''] ^
)''^ _
{(( 
TodayShortDate)) 
=))  
DateTime))! )
.))) *
Now))* -
.))- .
ToShortDateString)). ?
())? @
)))@ A
,))A B
RendezVousOfDay** 
=**  !
_rendezVousService**" 4
.++ .
"GetDayRendezVousWithPrestationName++ 7
<++7 8$
AdminRendezVousViewModel++8 P
>++P Q
(++Q R
DateTime++R Z
.++Z [
Now++[ ^
.++^ _
ToShortDateString++_ p
(++p q
)++q r
)++r s
,++s t
WaitingRendezVous,, !
=,," #
_rendezVousService,,$ 6
.,,6 7 
GetWaitingRendezVous,,7 K
<,,K L$
AdminRendezVousViewModel,,L d
>,,d e
(,,e f
),,f g
}-- 
;-- 
return.. 
PartialView.. 
(.. 
$str.. :
,..: ;
model..< A
)..A B
;..B C
}// 	
[11 	
HttpPost11	 
]11 
public22 
IActionResult22 $
GetPrestationsManagement22 5
(225 6
)226 7
{33 	
List55 
<55 $
AdminPrestationViewModel55 )
>55) *
model55+ 0
=551 2
_prestationService553 E
.55E F
GetAllPrestations55F W
<55W X$
AdminPrestationViewModel55X p
>55p q
(55q r
)55r s
;55s t
return66 
PartialView66 
(66 
$str66 >
,66> ?
model66@ E
)66E F
;66F G
}77 	
[99 	
HttpPost99	 
]99 
public:: 
IActionResult:: !
GetEditPrestationForm:: 2
(::2 3
Int32::3 8
idPrestation::9 E
)::E F
{;; 	$
AdminPrestationViewModel<< $
model<<% *
=<<+ ,
_prestationService<<- ?
.<<? @
GetPrestationById<<@ Q
<<<Q R$
AdminPrestationViewModel<<R j
><<j k
(<<k l
idPrestation<<l x
)<<x y
;<<y z
return>> 
PartialView>> 
(>> 
$str>> ;
,>>; <
model>>= B
)>>B C
;>>C D
}?? 	
[AA 	
HttpPostAA	 
]AA 
publicBB 
IActionResultBB 
GetDayRendezVousBB -
(BB- .
StringBB. 4
dateBB5 9
)BB9 :
{CC 	
ListDD 
<DD $
AdminRendezVousViewModelDD )
>DD) *

rendezVousDD+ 5
=DD6 7
_rendezVousServiceDD8 J
.DDJ K.
"GetDayRendezVousWithPrestationNameDDK m
<DDm n%
AdminRendezVousViewModel	DDn Ü
>
DDÜ á
(
DDá à
date
DDà å
)
DDå ç
;
DDç é
returnFF 
PartialViewFF 
(FF 

rendezVousFF )
)FF) *
;FF* +
}GG 	
[II 	
HttpPostII	 
]II 
publicJJ 
IActionResultJJ "
AcceptRejectRendezVousJJ 3
(JJ3 4
Int32JJ4 9
idRdvJJ: ?
,JJ? @
StringJJA G
commandJJH O
)JJO P
{KK 	
boolLL 
statusLL 
=LL 
_rendezVousServiceLL ,
.LL, -!
RendezVousValidRejectLL- B
(LLB C
idRdvLLC H
,LLH I
commandLLJ Q
)LLQ R
;LLR S
ListNN 
<NN $
AdminRendezVousViewModelNN )
>NN) *
waitingRendezVousNN+ <
=NN= >
_rendezVousServiceNN? Q
.NNQ R 
GetWaitingRendezVousNNR f
<NNf g$
AdminRendezVousViewModelNNg 
>	NN Ä
(
NNÄ Å
)
NNÅ Ç
;
NNÇ É
returnPP 
PartialViewPP 
(PP 
$strPP 2
,PP2 3
waitingRendezVousPP4 E
)PPE F
;PPF G
}QQ 	
[SS 	
HttpPostSS	 
]SS 
publicTT 
IActionResultTT  
GetAddPrestationFormTT 1
(TT1 2
)TT2 3
{UU 	
returnVV 
PartialViewVV 
(VV 
$strVV 7
)VV7 8
;VV8 9
}WW 	
}XX 
}YY Ó
PC:\Code\C#\FairyNails\sln\FairyNails\FairyNailsApp\Controllers\HomeController.cs
	namespace

 	
FairyNailsApp


 
.

 
Controllers

 #
{ 
public 

class 
HomeController 
:  !

Controller" ,
{ 
private 
readonly 
ILogger  
<  !
HomeController! /
>/ 0
_logger1 8
;8 9
public 
HomeController 
( 
ILogger %
<% &
HomeController& 4
>4 5
logger6 <
)< =
{ 	
_logger 
= 
logger 
; 
} 	
public 
IActionResult 
Index "
(" #
)# $
{ 	
return 
View 
( 
) 
; 
} 	
public 
IActionResult 
Privacy $
($ %
)% &
{ 	
return 
View 
( 
) 
; 
} 	
[ 	
ResponseCache	 
( 
Duration 
=  !
$num" #
,# $
Location% -
=. /!
ResponseCacheLocation0 E
.E F
NoneF J
,J K
NoStoreL S
=T U
trueV Z
)Z [
][ \
public   
IActionResult   
Error   "
(  " #
)  # $
{!! 	
return"" 
View"" 
("" 
new"" 
ErrorViewModel"" *
{""+ ,
	RequestId""- 6
=""7 8
Activity""9 A
.""A B
Current""B I
?""I J
.""J K
Id""K M
??""N P
HttpContext""Q \
.""\ ]
TraceIdentifier""] l
}""m n
)""n o
;""o p
}## 	
}$$ 
}%% Ó

VC:\Code\C#\FairyNails\sln\FairyNails\FairyNailsApp\Controllers\PrestationController.cs
	namespace		 	
FairyNailsApp		
 
.		 
Controllers		 #
{

 
public 

class  
PrestationController %
:& '

Controller( 2
{ 
private 
readonly 
IPrestationService +
_prestationService, >
;> ?
public  
PrestationController #
(# $
IPrestationService$ 6
prestationService7 H
)H I
{ 	
this 
. 
_prestationService #
=$ %
prestationService& 7
;7 8
} 	
public 
IActionResult 
Index "
(" #
)# $
{ 	
IndexViewModel 
model  
=! "
new# &
IndexViewModel' 5
(5 6
)6 7
{ 
Prestations 
= 
_prestationService 0
.0 1
GetAllPrestations1 B
<B C
PrestationViewModelC V
>V W
(W X
)X Y
} 
; 
return 
View 
( 
model 
) 
; 
} 	
} 
} «%
VC:\Code\C#\FairyNails\sln\FairyNails\FairyNailsApp\Controllers\RendezVousController.cs
	namespace 	
FairyNailsApp
 
. 
Controllers #
{ 
[ 
	Authorize 
] 
public 

class  
RendezVousController %
:& '

Controller( 2
{ 
private 
readonly 
IRendezVousService +
_rendezVousService, >
;> ?
private 
readonly 
IPrestationService +
_prestationService, >
;> ?
public  
RendezVousController #
($ %
IRendezVousService% 7
rendezVousService8 I
,I J
IPrestationServiceK ]
prestationService^ o
)o p
{ 	
this 
. 
_rendezVousService #
=$ %
rendezVousService& 7
;7 8
this 
. 
_prestationService #
=$ %
prestationService& 7
;7 8
} 	
public 
IActionResult 
Index "
(" #
)# $
{ 	
return 
RedirectToAction #
(# $
$str$ .
). /
;/ 0
} 	
public   
IActionResult   
Calendar   %
(  % &
)  & '
{!! 	
CalendarViewModel## 
model## #
=##$ %
new##& )
CalendarViewModel##* ;
(##; <
)##< =
{$$ 
Prestations%% 
=%% 
_prestationService%% 0
.%%0 1
GetAllPrestations%%1 B
<%%B C
PrestationViewModel%%C V
>%%V W
(%%W X
)%%X Y
,%%Y Z
UnavaibleTimeCode&& !
=&&" #
_rendezVousService&&$ 6
.&&6 7"
GetUnavailableDateCode&&7 M
(&&M N
DateTime&&N V
.&&V W
Now&&W Z
.&&Z [
Month&&[ `
)&&` a
,&&a b
FirstDayOfMonth'' 
=''  !
new''" %
DateTime''& .
(''. /
DateTime''/ 7
.''7 8
Now''8 ;
.''; <
Year''< @
,''@ A
DateTime''B J
.''J K
Now''K N
.''N O
Month''O T
,''T U
$num''V W
)''W X
}(( 
;(( 
return** 
View** 
(** 
model** 
)** 
;** 
}++ 	
[-- 	
HttpPost--	 
]-- 
public.. 
IActionResult.. 
SaveRendezVous.. +
(..+ ,
CalendarViewModel.., =
rdvData..> E
)..E F
{// 	
if00 
(00 

ModelState00 
.00 
IsValid00 !
)00! "
{11 
List22 
<22 
Int3222 
>22 
prestationChosenId22 .
=22/ 0
new221 4
List225 9
<229 :
Int3222: ?
>22? @
(22@ A
)22A B
;22B C
foreach33 
(33 
var33 

prestation33 '
in33( *
rdvData33+ 2
.332 3
Prestations333 >
)33> ?
{44 
if55 
(55 

prestation55 !
.55! "
IsChosen55" *
)55* +
{66 
prestationChosenId77 *
.77* +
Add77+ .
(77. /

prestation77/ 9
.779 :
IdPrestation77: F
)77F G
;77G H
}88 
}99 
bool;; 
	addStatus;; 
=;;  
_rendezVousService;;! 3
.;;3 4
AddRendezVous;;4 A
(;;A B
rdvData;;B I
.;;I J
IdClient;;J R
,;;R S
prestationChosenId;;T f
,;;f g
rdvData;;h o
.;;o p
DateCode;;p x
);;x y
;;;y z
if== 
(== 
	addStatus== 
====  
true==! %
)==% &
{>> 
TempData?? 
[?? 
$str?? &
]??& '
=??( )
$str??* d
;??d e
}@@ 
elseAA 
{BB 
TempDataCC 
[CC 
$strCC $
]CC$ %
=CC& '
$strCC( R
;CCR S
}DD 
}EE 
elseFF 
{GG 
TempDataHH 
[HH 
$strHH  
]HH  !
=HH" #
$strHH$ `
;HH` a
}II 
returnJJ 
RedirectToActionJJ #
(JJ# $
$strJJ$ .
)JJ. /
;JJ/ 0
}KK 	
}LL 
}MM ∫	
[C:\Code\C#\FairyNails\sln\FairyNails\FairyNailsApp\Models\Admin\AdminPrestationViewModel.cs
	namespace 	
FairyNailsApp
 
. 
Models 
. 
Admin $
{		 
public

 

class

 $
AdminPrestationViewModel

 )
:

* +
IPrestation

, 7
{ 
public 
int 
IdPrestation 
{  !
get" %
;& '
set( +
;, -
}. /
[ 	
Required	 
] 
public 
string 
Nom 
{ 
get 
;  
set! $
;$ %
}& '
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
decimal 
Prix 
{ 
get !
;! "
set# &
;& '
}( )
public 
TimeSpan 
Duree 
{ 
get  #
;# $
set% (
;( )
}* +
} 
} ë
eC:\Code\C#\FairyNails\sln\FairyNails\FairyNailsApp\Models\Admin\AdminRendezVousManagementViewModel.cs
	namespace		 	
FairyNailsApp		
 
.		 
Models		 
.		 
Admin		 $
{

 
public 

class .
"AdminRendezVousManagementViewModel 3
{ 
public 
List 
< $
AdminRendezVousViewModel ,
>, -
RendezVousOfDay. =
{> ?
get@ C
;C D
setE H
;H I
}J K
public 
List 
< $
AdminRendezVousViewModel ,
>, -
WaitingRendezVous. ?
{@ A
getB E
;E F
setG J
;J K
}L M
public 
String 
TodayShortDate $
{% &
get' *
;* +
set, /
;/ 0
}1 2
} 
public 

class $
AdminRendezVousViewModel )
:* +
IRendezVous, 7
{ 
public 
int 
IdRdv 
{ 
get 
; 
set  #
;# $
}% &
public 
DateTime 
DateRdv 
{  !
get" %
;% &
set' *
;* +
}, -
public 
decimal 
	PrixTotal  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
TimeSpan 

DureeTotal "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
string 
IdClient 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
ApplicationUser 
IdClientNavigation 1
{2 3
get4 7
;7 8
set9 <
;< =
}> ?
public 
List 
< 
string 
> 
Prestations '
{( )
get* -
;- .
set/ 2
;3 4
}5 6
public 
bool 
Validate 
{ 
get "
;" #
set$ '
;' (
}) *
} 
} ö
KC:\Code\C#\FairyNails\sln\FairyNails\FairyNailsApp\Models\ErrorViewModel.cs
	namespace 	
FairyNailsApp
 
. 
Models 
{ 
public 

class 
ErrorViewModel 
{ 
public 
string 
	RequestId 
{  !
get" %
;% &
set' *
;* +
}, -
public		 
bool		 
ShowRequestId		 !
=>		" $
!		% &
string		& ,
.		, -
IsNullOrEmpty		- :
(		: ;
	RequestId		; D
)		D E
;		E F
}

 
} ÿ
VC:\Code\C#\FairyNails\sln\FairyNails\FairyNailsApp\Models\Prestation\IndexViewModel.cs
	namespace 	
FairyNailsApp
 
. 
Models 
. 

Prestation )
{ 
public		 

class		 
IndexViewModel		 
{

 
public 
List 
< 
PrestationViewModel '
>' (
Prestations) 4
{5 6
get7 :
;: ;
set< ?
;? @
}A B
} 
public 

class 
PrestationViewModel $
:% &
IPrestation' 2
{ 
public 
int 
IdPrestation 
{  !
get" %
;% &
set' *
;* +
}, -
public 
string 
Nom 
{ 
get 
;  
set! $
;$ %
}& '
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
decimal 
Prix 
{ 
get !
;! "
set# &
;& '
}( )
public 
TimeSpan 
Duree 
{ 
get  #
;# $
set% (
;( )
}* +
public 
bool 
IsChosen 
{ 
get "
;" #
set$ '
;' (
}) *
} 
} ·	
YC:\Code\C#\FairyNails\sln\FairyNails\FairyNailsApp\Models\RendezVous\CalendarViewModel.cs
	namespace 	
FairyNailsApp
 
. 
Models 
. 

RendezVous )
{		 
public

 

class

 
CalendarViewModel

 "
{ 
public 
String 
DateCode 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
IdClient 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
List 
< 
PrestationViewModel '
>' (
Prestations) 4
{5 6
get7 :
;: ;
set< ?
;? @
}A B
public 
List 
< 
String 
> 
UnavaibleTimeCode -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
public 
DateTime 
FirstDayOfMonth '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
} 
} ò

=C:\Code\C#\FairyNails\sln\FairyNails\FairyNailsApp\Program.cs
	namespace

 	
FairyNailsApp


 
{ 
public 

class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{ 	
CreateHostBuilder 
( 
args "
)" #
.# $
Build$ )
() *
)* +
.+ ,
Run, /
(/ 0
)0 1
;1 2
} 	
public 
static 
IHostBuilder "
CreateHostBuilder# 4
(4 5
string5 ;
[; <
]< =
args> B
)B C
=>D F
Host 
.  
CreateDefaultBuilder %
(% &
args& *
)* +
. $
ConfigureWebHostDefaults )
() *

webBuilder* 4
=>5 7
{ 

webBuilder 
. 

UseStartup )
<) *
Startup* 1
>1 2
(2 3
)3 4
;4 5
} 
) 
; 
} 
} ∏"
=C:\Code\C#\FairyNails\sln\FairyNails\FairyNailsApp\Startup.cs
	namespace 	
FairyNailsApp
 
{ 
public 

class 
Startup 
{ 
public 
Startup 
( 
IConfiguration %
configuration& 3
)3 4
{ 	
Configuration 
= 
configuration )
;) *
} 	
public 
IConfiguration 
Configuration +
{, -
get. 1
;1 2
}3 4
public 
void 
ConfigureServices %
(% &
IServiceCollection& 8
services9 A
)A B
{ 	
services 
. 
AddDbContext !
<! "
FairynailsContext" 3
>3 4
(4 5
options5 <
=>= ?
options 
. 
UseSqlServer $
($ %
Configuration !
.! "
GetConnectionString" 5
(5 6
$str6 K
)K L
,L M
b 
=> 
b 
. 
MigrationsAssembly -
(- .
$str. B
)B C
)C D
)D E
;E F
services   
.   
AddDefaultIdentity   '
<  ' (
ApplicationUser  ( 7
>  7 8
(  8 9
)  9 :
.!! 
AddRoles!! 
<!! 
IdentityRole!! &
>!!& '
(!!' (
)!!( )
."" $
AddEntityFrameworkStores"" )
<"") *
FairynailsContext""* ;
>""; <
(""< =
)""= >
;""> ?
services## 
.## #
AddControllersWithViews## ,
(##, -
)##- .
;##. /
services$$ 
.$$ 
AddRazorPages$$ "
($$" #
)$$# $
;$$$ %
services'' 
.'' 
	AddScoped'' 
<'' 
IRendezVousService'' 1
,''1 2
RendezVousService''2 C
>''C D
(''D E
)''E F
;''F G
services(( 
.(( 
	AddScoped(( 
<(( 
IPrestationService(( 1
,((1 2
PrestationService((2 C
>((C D
(((D E
)((E F
;((F G
})) 	
public,, 
void,, 
	Configure,, 
(,, 
IApplicationBuilder,, 1
app,,2 5
,,,5 6
IWebHostEnvironment,,7 J
env,,K N
),,N O
{-- 	
if.. 
(.. 
env.. 
... 
IsDevelopment.. !
(..! "
).." #
)..# $
{// 
app00 
.00 %
UseDeveloperExceptionPage00 -
(00- .
)00. /
;00/ 0
app11 
.11  
UseDatabaseErrorPage11 (
(11( )
)11) *
;11* +
}22 
else33 
{44 
app55 
.55 
UseExceptionHandler55 '
(55' (
$str55( 5
)555 6
;556 7
app77 
.77 
UseHsts77 
(77 
)77 
;77 
}88 
app99 
.99 
UseHttpsRedirection99 #
(99# $
)99$ %
;99% &
app:: 
.:: 
UseStaticFiles:: 
(:: 
)::  
;::  !
app<< 
.<< 

UseRouting<< 
(<< 
)<< 
;<< 
app>> 
.>> 
UseAuthentication>> !
(>>! "
)>>" #
;>># $
app?? 
.?? 
UseAuthorization??  
(??  !
)??! "
;??" #
appAA 
.AA 
UseEndpointsAA 
(AA 
	endpointsAA &
=>AA' )
{BB 
	endpointsCC 
.CC 
MapControllerRouteCC ,
(CC, -
nameDD 
:DD 
$strDD #
,DD# $
patternEE 
:EE 
$strEE E
)EEE F
;EEF G
	endpointsFF 
.FF 
MapRazorPagesFF '
(FF' (
)FF( )
;FF) *
}GG 
)GG 
;GG 
}HH 	
}II 
}JJ 