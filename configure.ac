AC_INIT([mono-webbrowser], [0.1.0])
AC_PREREQ(2.50)
AC_CONFIG_AUX_DIR(.)
AM_INIT_AUTOMAKE([1.9 tar-ustar])
AM_MAINTAINER_MODE

AC_PROG_INSTALL

DISTCHECK_CONFIGURE_FLAGS="--disable-docs"
AC_SUBST(DISTCHECK_CONFIGURE_FLAGS)

API_VERSION="0.5.0.0"
POLICY_VERSIONS="1.0 2.0"
ASSEMBLY_COMPANY="Novell, Inc."
ASSEMBLY_COPYRIGHT="2008 Novell, Inc."
ASSEMBLY_PRODUCT="Mono.WebBrowser"
MONO_PACKAGE="2.0"
						 
AC_SUBST(API_VERSION)
AC_SUBST(POLICY_VERSIONS)
AC_SUBST(ASSEMBLY_COMPANY)
AC_SUBST(ASSEMBLY_COPYRIGHT)
AC_SUBST(ASSEMBLY_PRODUCT)
AC_SUBST(MONO_PACKAGE)

AC_PATH_PROG(GACUTIL, gacutil, no)
if test "x$GACUTIL" = "xno"; then
	AC_MSG_ERROR([You need to install gacutil])
fi
GACUTIL_FLAGS=
#'-package $(MONO_PACKAGE) -root $(DESTDIR)$(prefix)/lib'
GACUTIL_POLICY_FLAGS='-root $(DESTDIR)$(prefix)/lib'
AC_SUBST(GACUTIL_FLAGS)
AC_SUBST(GACUTIL_POLICY_FLAGS)

SHAMROCK_CHECK_MONO_MODULE(1.1.10)
SHAMROCK_FIND_MONO_2_0_COMPILER
SHAMROCK_FIND_MONO_RUNTIME
SHAMROCK_CHECK_MONODOC


AC_ARG_ENABLE([webkit],
	AC_HELP_STRING([--enable-webkit], [Build WebKit backend (default=yes)]),
	[
		case "${enableval}" in
			yes) webkit=yes ;;
			no) webkit=no ;;
			*) AC_MSG_ERROR(bad value ${enableval} for --enable-webkit) ;;
		esac
	],
	[webkit=yes]
)

if test ! -d "$srcdir/mono-webkit" ; then
	if test x"$webkit" = x"yes"; then
		webkit=no
		AC_MSG_NOTICE(WebKit backend not available to build)
	fi
fi

if test x$webkit = x"yes"; then
	AC_MSG_NOTICE(Configuring the WebKit backend)
	WEBKIT_NAME="mono-webkit"
	WEBKIT_PRODUCT="mono-webkit"
	WEBKIT_DESCRIPTION="Managed Wrapper for the webkit engine"
			
	AC_SUBST(WEBKIT_NAME)
	AC_SUBST(WEBKIT_PRODUCT)
	AC_SUBST(WEBKIT_DESCRIPTION)


	SHAMROCK_CHECK_MONO_2_0_GAC_ASSEMBLIES(System Mono.WebBrowser)

	WEBKIT_REFERENCES="-r:System -r:Mono.WebBrowser"
	AC_SUBST(WEBKIT_REFERENCES)

	PKG_CHECK_MODULES(GTKSHARP, gtk-sharp-2.0 glib-sharp-2.0 glade-sharp-2.0)
	AC_SUBST(GTKSHARP_LIBS)

	PKG_CHECK_MODULES(WEBKITSHARP, webkit-sharp-1.0)
	AC_SUBST(WEBKITSHARP_LIBS)
	
	AC_CONFIG_FILES([
		mono-webkit/Makefile
		mono-webkit/AssemblyInfo.cs
	])
fi

AM_CONDITIONAL(BUILD_WEBKIT, test x$webkit = xyes)

AC_ARG_ENABLE([tests],
	AC_HELP_STRING([--enable-tests], [Build tests (default=yes)]),
	[
		case "${enableval}" in
			yes) tests=yes ;;
			no) tests=no ;;
			*) AC_MSG_ERROR(bad value ${enableval} for --enable-tests) ;;
		esac
	],
	[tests=yes]
)

if test [ x$tests = x"yes" ]; then
	AC_CONFIG_FILES([
		tests/Makefile
		tests/simple/Makefile
	])
fi

AM_CONDITIONAL(BUILD_TESTS, test x$tests = xyes)

SHAMROCK_EXPAND_LIBDIR

AC_CONFIG_FILES([
Makefile
])


AC_OUTPUT
