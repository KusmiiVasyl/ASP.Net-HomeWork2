document.querySelectorAll('#culture-options li div').forEach(option => {
	option.addEventListener("click", changeLanguage);
});

const cultureMap = {
	en: 'en',
	uk: 'uk'
};

// set culture coockie from browser/user default language
if (!document.cookie.includes('.culture')) {
	var userCulture = cultureMap[navigator.language] || navigator.language;

	// set backend culture cookie
	setCookie('.AspNetCore.Culture', `c=${userCulture}|uic=${userCulture}`);

	// set frontend culture cookie
	setCookie('.culture', userCulture);

	location.reload()
}

function changeLanguage() {
	const culture = cultureMap[this.attributes.value.value] || this.attributes.value.value;

	document.getElementById('lang-select-span').innerText = this.innerText

	// set backend culture cookie
	setCookie('.AspNetCore.Culture', `c=${culture}|uic=${culture}`);

	// set frontend culture cookie
	setCookie('.culture', culture);

	location.reload()
}

function setCookie(cName, cValue) {
	let date = new Date();
	date.setFullYear(date.getFullYear() + 1)
	const expires = `expires=${date.toUTCString()}`;
	document.cookie = `${cName}=${cValue}; ${expires}; path=/`;
}
