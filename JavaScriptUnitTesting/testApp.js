var TestApp = {

  add: function(a, b) {
    return a + b;
  },

  getWorkInfo: function() {
    $.ajax({
      url: '/work/info',
      dataType: 'json',
      success: TestApp.updateWorkInfo
    });
  },

  updateWorkInfo: function(data) {
    $('#workDescription').html(data.Description);
    $('#workReference').html(data.WorkReference);

    $('#workSteps')
      .append('<table><tr><td>Hello</td></tr></table>')
      .append('<td>Two</td>');

  alert($('#workSteps').html());
  }
  
};

