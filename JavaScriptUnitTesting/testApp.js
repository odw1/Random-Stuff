String.prototype.format = function() {
  var formatted = this;
  for (arg in arguments) {
    formatted = formatted.replace('{' + arg + '}', arguments[arg]);
  }
  return formatted;
};

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
      .append('<table></table>')

    var table = $('#workSteps').children().last();

    table.append('<tr><th>Id</th><th>Name</th></tr>');
    
    var stepRow = '<tr><td>{0}</td><td>{1}</td></tr>';

    for (var step in data.Steps) {
      var currentStep = data.Steps[step];
      table.append(stepRow.format(currentStep.Id, currentStep.Name));
    }
  }
  
};
