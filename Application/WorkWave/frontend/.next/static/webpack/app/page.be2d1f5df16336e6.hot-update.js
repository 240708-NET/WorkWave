"use strict";
/*
 * ATTENTION: An "eval-source-map" devtool has been used.
 * This devtool is neither made for production nor for readable output files.
 * It uses "eval()" calls to create a separate source file with attached SourceMaps in the browser devtools.
 * If you are trying to read the output file, select a different devtool (https://webpack.js.org/configuration/devtool/)
 * or disable the default devtool with "devtool: false".
 * If you are looking for production-ready output files, see mode: "production" (https://webpack.js.org/configuration/mode/).
 */
self["webpackHotUpdate_N_E"]("app/page",{

/***/ "(app-pages-browser)/./app/components/Column/Column.tsx":
/*!******************************************!*\
  !*** ./app/components/Column/Column.tsx ***!
  \******************************************/
/***/ (function(module, __webpack_exports__, __webpack_require__) {

eval(__webpack_require__.ts("__webpack_require__.r(__webpack_exports__);\n/* harmony import */ var react_jsx_dev_runtime__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! react/jsx-dev-runtime */ \"(app-pages-browser)/./node_modules/next/dist/compiled/react/jsx-dev-runtime.js\");\n/* harmony import */ var _Column_module_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./Column.module.css */ \"(app-pages-browser)/./app/components/Column/Column.module.css\");\n/* harmony import */ var _Column_module_css__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(_Column_module_css__WEBPACK_IMPORTED_MODULE_1__);\n/* harmony import */ var _app_components_Card_Card__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @/app/components/Card/Card */ \"(app-pages-browser)/./app/components/Card/Card.tsx\");\n\n\n\nfunction Column(param) {\n    let { name, tasks, onDrop, onDragOver } = param;\n    return /*#__PURE__*/ (0,react_jsx_dev_runtime__WEBPACK_IMPORTED_MODULE_0__.jsxDEV)(\"div\", {\n        className: (_Column_module_css__WEBPACK_IMPORTED_MODULE_1___default().column),\n        onDrop: (event)=>onDrop(event, name),\n        onDragOver: (event)=>onDragOver(event),\n        children: [\n            /*#__PURE__*/ (0,react_jsx_dev_runtime__WEBPACK_IMPORTED_MODULE_0__.jsxDEV)(\"h5\", {\n                children: name\n            }, void 0, false, {\n                fileName: \"/Volumes/Elements/Team6/WorkWave/Application/WorkWave/frontend/app/components/Column/Column.tsx\",\n                lineNumber: 27,\n                columnNumber: 7\n            }, this),\n            tasks.map((task, index)=>/*#__PURE__*/ (0,react_jsx_dev_runtime__WEBPACK_IMPORTED_MODULE_0__.jsxDEV)(_app_components_Card_Card__WEBPACK_IMPORTED_MODULE_2__[\"default\"], {\n                    task: task,\n                    onDragStart: (event)=>onDragStart(event, task)\n                }, index, false, {\n                    fileName: \"/Volumes/Elements/Team6/WorkWave/Application/WorkWave/frontend/app/components/Column/Column.tsx\",\n                    lineNumber: 29,\n                    columnNumber: 9\n                }, this))\n        ]\n    }, void 0, true, {\n        fileName: \"/Volumes/Elements/Team6/WorkWave/Application/WorkWave/frontend/app/components/Column/Column.tsx\",\n        lineNumber: 22,\n        columnNumber: 5\n    }, this);\n}\n_c = Column;\n/* harmony default export */ __webpack_exports__[\"default\"] = (Column);\nvar _c;\n$RefreshReg$(_c, \"Column\");\n\n\n;\n    // Wrapped in an IIFE to avoid polluting the global scope\n    ;\n    (function () {\n        var _a, _b;\n        // Legacy CSS implementations will `eval` browser code in a Node.js context\n        // to extract CSS. For backwards compatibility, we need to check we're in a\n        // browser context before continuing.\n        if (typeof self !== 'undefined' &&\n            // AMP / No-JS mode does not inject these helpers:\n            '$RefreshHelpers$' in self) {\n            // @ts-ignore __webpack_module__ is global\n            var currentExports = module.exports;\n            // @ts-ignore __webpack_module__ is global\n            var prevSignature = (_b = (_a = module.hot.data) === null || _a === void 0 ? void 0 : _a.prevSignature) !== null && _b !== void 0 ? _b : null;\n            // This cannot happen in MainTemplate because the exports mismatch between\n            // templating and execution.\n            self.$RefreshHelpers$.registerExportsForReactRefresh(currentExports, module.id);\n            // A module can be accepted automatically based on its exports, e.g. when\n            // it is a Refresh Boundary.\n            if (self.$RefreshHelpers$.isReactRefreshBoundary(currentExports)) {\n                // Save the previous exports signature on update so we can compare the boundary\n                // signatures. We avoid saving exports themselves since it causes memory leaks (https://github.com/vercel/next.js/pull/53797)\n                module.hot.dispose(function (data) {\n                    data.prevSignature =\n                        self.$RefreshHelpers$.getRefreshBoundarySignature(currentExports);\n                });\n                // Unconditionally accept an update to this module, we'll check if it's\n                // still a Refresh Boundary later.\n                // @ts-ignore importMeta is replaced in the loader\n                module.hot.accept();\n                // This field is set when the previous version of this module was a\n                // Refresh Boundary, letting us know we need to check for invalidation or\n                // enqueue an update.\n                if (prevSignature !== null) {\n                    // A boundary can become ineligible if its exports are incompatible\n                    // with the previous exports.\n                    //\n                    // For example, if you add/remove/change exports, we'll want to\n                    // re-execute the importing modules, and force those components to\n                    // re-render. Similarly, if you convert a class component to a\n                    // function, we want to invalidate the boundary.\n                    if (self.$RefreshHelpers$.shouldInvalidateReactRefreshBoundary(prevSignature, self.$RefreshHelpers$.getRefreshBoundarySignature(currentExports))) {\n                        module.hot.invalidate();\n                    }\n                    else {\n                        self.$RefreshHelpers$.scheduleUpdate();\n                    }\n                }\n            }\n            else {\n                // Since we just executed the code for the module, it's possible that the\n                // new exports made it ineligible for being a boundary.\n                // We only care about the case when we were _previously_ a boundary,\n                // because we already accepted this update (accidental side effect).\n                var isNoLongerABoundary = prevSignature !== null;\n                if (isNoLongerABoundary) {\n                    module.hot.invalidate();\n                }\n            }\n        }\n    })();\n//# sourceURL=[module]\n//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiKGFwcC1wYWdlcy1icm93c2VyKS8uL2FwcC9jb21wb25lbnRzL0NvbHVtbi9Db2x1bW4udHN4IiwibWFwcGluZ3MiOiI7Ozs7OztBQUEyQztBQUNHO0FBa0I5QyxTQUFTRSxPQUFPLEtBQWdEO1FBQWhELEVBQUVDLElBQUksRUFBRUMsS0FBSyxFQUFFQyxNQUFNLEVBQUVDLFVBQVUsRUFBZSxHQUFoRDtJQUNkLHFCQUNFLDhEQUFDQztRQUNDQyxXQUFXUixrRUFBZ0I7UUFDM0JLLFFBQVEsQ0FBQ0ssUUFBVUwsT0FBT0ssT0FBT1A7UUFDakNHLFlBQVksQ0FBQ0ksUUFBVUosV0FBV0k7OzBCQUVsQyw4REFBQ0M7MEJBQUlSOzs7Ozs7WUFDSkMsTUFBTVEsR0FBRyxDQUFDLENBQUNDLE1BQU1DLHNCQUNoQiw4REFBQ2IsaUVBQUlBO29CQUFhWSxNQUFNQTtvQkFBTUUsYUFBYSxDQUFDTCxRQUFVSyxZQUFZTCxPQUFPRzttQkFBOURDOzs7Ozs7Ozs7OztBQUluQjtLQWJTWjtBQWVULCtEQUFlQSxNQUFNQSxFQUFDIiwic291cmNlcyI6WyJ3ZWJwYWNrOi8vX05fRS8uL2FwcC9jb21wb25lbnRzL0NvbHVtbi9Db2x1bW4udHN4PzFkMDYiXSwic291cmNlc0NvbnRlbnQiOlsiaW1wb3J0IGNvbHN0eWxlcyBmcm9tIFwiLi9Db2x1bW4ubW9kdWxlLmNzc1wiXG5pbXBvcnQgQ2FyZCBmcm9tIFwiQC9hcHAvY29tcG9uZW50cy9DYXJkL0NhcmRcIjtcblxuXG5pbnRlcmZhY2UgQ29sdW1uUHJvcHMge1xuICAgIG5hbWU6IHN0cmluZztcbiAgICB0YXNrczogc3RyaW5nW107XG4gICAgb25Ecm9wOiAoZXZlbnQ6IFJlYWN0LkRyYWdFdmVudDxIVE1MRGl2RWxlbWVudD4sIGNvbHVtbk5hbWU6IHN0cmluZykgPT4gdm9pZDtcbiAgICBvbkRyYWdPdmVyOiAoZXZlbnQ6IFJlYWN0LkRyYWdFdmVudDxIVE1MRGl2RWxlbWVudD4pID0+IHZvaWQ7XG4gIH1cblxuXG5pbnRlcmZhY2UgQ29sdW1uUHJvcHMge1xuICBuYW1lOiBzdHJpbmc7XG4gIHRhc2tzOiBzdHJpbmdbXTtcbiAgb25Ecm9wOiAoZXZlbnQ6IFJlYWN0LkRyYWdFdmVudDxIVE1MRGl2RWxlbWVudD4sIGNvbHVtbk5hbWU6IHN0cmluZykgPT4gdm9pZDtcbiAgb25EcmFnT3ZlcjogKGV2ZW50OiBSZWFjdC5EcmFnRXZlbnQ8SFRNTERpdkVsZW1lbnQ+KSA9PiB2b2lkO1xufVxuXG5mdW5jdGlvbiBDb2x1bW4oeyBuYW1lLCB0YXNrcywgb25Ecm9wLCBvbkRyYWdPdmVyIH06IENvbHVtblByb3BzKSB7XG4gIHJldHVybiAoXG4gICAgPGRpdlxuICAgICAgY2xhc3NOYW1lPXtjb2xzdHlsZXMuY29sdW1ufVxuICAgICAgb25Ecm9wPXsoZXZlbnQpID0+IG9uRHJvcChldmVudCwgbmFtZSl9XG4gICAgICBvbkRyYWdPdmVyPXsoZXZlbnQpID0+IG9uRHJhZ092ZXIoZXZlbnQpfVxuICAgID5cbiAgICAgIDxoNT57bmFtZX08L2g1PlxuICAgICAge3Rhc2tzLm1hcCgodGFzaywgaW5kZXgpID0+IChcbiAgICAgICAgPENhcmQga2V5PXtpbmRleH0gdGFzaz17dGFza30gb25EcmFnU3RhcnQ9eyhldmVudCkgPT4gb25EcmFnU3RhcnQoZXZlbnQsIHRhc2spfSAvPlxuICAgICAgKSl9XG4gICAgPC9kaXY+XG4gICk7XG59XG5cbmV4cG9ydCBkZWZhdWx0IENvbHVtbjsiXSwibmFtZXMiOlsiY29sc3R5bGVzIiwiQ2FyZCIsIkNvbHVtbiIsIm5hbWUiLCJ0YXNrcyIsIm9uRHJvcCIsIm9uRHJhZ092ZXIiLCJkaXYiLCJjbGFzc05hbWUiLCJjb2x1bW4iLCJldmVudCIsImg1IiwibWFwIiwidGFzayIsImluZGV4Iiwib25EcmFnU3RhcnQiXSwic291cmNlUm9vdCI6IiJ9\n//# sourceURL=webpack-internal:///(app-pages-browser)/./app/components/Column/Column.tsx\n"));

/***/ })

});