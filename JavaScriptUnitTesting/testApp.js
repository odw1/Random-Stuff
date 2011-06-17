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
    alert('hello');
  }
  
};
