noinst_DATA=$(WEBKIT_NAME).dll

DIST_SOURCES = \
	DebugHelper.cs \
	EmbedWidget.cs \
	WebBrowser.cs \
	XEvent.cs

mono_webkit_sources_in=AssemblyInfo.cs.in
mono_webkit_generated_sources=$(mono_webkit_sources_in:.in=)
mono_webkit_build_sources = $(addprefix $(srcdir)/, $(DIST_SOURCES))
mono_webkit_build_sources += $(mono_webkit_generated_sources)

mono-webkit.dll: $(mono_webkit_build_sources)
	$(MCS) -debug -define:DEBUG -target:library -out:$@ $(WEBKIT_REFERENCES) $(GTKSHARP_LIBS) $(WEBKITSHARP_LIBS) $(mono_webkit_build_sources)

EXTRA_DIST = mono-webkit.snk
 
CLEANFILES = mono-webkit.dll mono-webkit.dll.mdb

DISTCLEANFILES = *.pidb $mono_webkit_sources_in

MAINTAINERCLEANFILES = Makefile.in

noinst_DATA = $(WEBKIT_NAME).dll

install-data-local:
	echo "$(GACUTIL) /i $(WEBKIT_NAME).dll /f $(GACUTIL_FLAGS)";  \
        $(GACUTIL) /i $(WEBKIT_NAME).dll /f $(GACUTIL_FLAGS) || exit 1;

uninstall-local:
	echo "$(GACUTIL) /u $(WEBKIT_NAME) $(GACUTIL_FLAGS)"; \
        $(GACUTIL) /u $(WEBKIT_NAME) $(GACUTIL_FLAGS) || exit 1;
