const notifications = (() => {
  $(document).on({
    ajaxStart: () => $('#loadingBox').fadeIn(),
    ajaxStop: () => $('#loadingBox').fadeOut()
  });

  function showSuccess(message) {
    let successBox = $('#successBox');
    successBox.text(message);
    successBox.fadeIn();
    successBox.fadeOut(5000);
  }

  function showError(message) {
    let errorBox = $('#errorBox');
    errorBox.text(message);
    errorBox.fadeIn();
    errorBox.fadeOut(5000);
  }

  return {
    showSuccess,
    showError
  }
})();