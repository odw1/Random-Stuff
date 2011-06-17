describe('testApp adding tests', function() {

  it('should add two numbers', function() {
    // Tests the result of a call
    var result = TestApp.add(10, 5);

    expect(result).toEqual(15);
  });
});

describe('testApp get work info tests', function() {

  it('it should retrieve the work info', function() {
    // Tests that jQuery.ajax was called correctly
    spyOn($, 'ajax');
    
    TestApp.getWorkInfo();
    expect($.ajax.mostRecentCall.args[0]['url']).toEqual('/work/info');
  });

  it('it should pass the result of the call to the update work info function', function() {
    // Tests that the data returned by the ajax call is passed to updateworkInfo function
    var returnedData = 'abc';
  
    spyOn(TestApp, 'updateWorkInfo');
    spyOn($, 'ajax').andCallFake(function(options) { options.success(returnedData); });

    TestApp.getWorkInfo();
    expect(TestApp.updateWorkInfo).toHaveBeenCalledWith('abc');
  });
});
