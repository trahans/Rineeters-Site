angular.module('parallax', []).directive('angParallax', [
  '$window', function ($window) {

    return {
      restrict: 'A',
      scope: {
        pCss: '@',
        pInitVal: '@',
        pRatio: '@'
      },
      link: function(iScope, iElem, iAttr) {
        var cssKey,
          cssValue,
          isSpecialVal,
          pCssVal,
          pOffset,
          pRatio,
          pInitVal,
          cssValArray;

        pCssVal = iScope.pCss ? iScope.pCss : 'top';
        cssValArray = pCssVal.split(':');
        cssKey = cssValArray[0];
        cssValue = cssValArray[1];

        isSpecialVal = cssValue ? true : false;
        if (!cssValue) cssValue = cssKey;

        pRatio = iScope.pRatio ? +iScope.pRatio : 1.1;
        pInitVal = iScope.pInitVal ? +iScope.pInitVal : 0;

        iElem.css(cssKey, pInitVal + 'px');

        function _onScroll() {
          var resultVal;
          var calcVal = $window.pageYOffset * pRatio + pInitVal;

          if (isSpecialVal) {
            resultVal = '' + cssValue + '(' + calcVal + 'px)';
          } else {
            resultVal = calcVal + 'px';
          }
          iElem.css(cssKey, resultVal);
        };

        $window.addEventListener('scroll', _onScroll);

      }
    };
  }
]);
