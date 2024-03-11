package com.uni.lista1.models;

import jakarta.persistence.*;

@Entity
public class Adres {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    @ManyToOne
    private Kraj kraj;

    private String miejscowosc;
    private String kodPocztowy;
    private String poczta;
    private String ulica;
    private String nrDomu;
    private String nrLokalu;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Kraj getKraj() {
        return kraj;
    }

    public void setKraj(Kraj kraj) {
        this.kraj = kraj;
    }

    public String getMiejscowosc() {
        return miejscowosc;
    }

    public void setMiejscowosc(String miejscowosc) {
        this.miejscowosc = miejscowosc;
    }

    public String getKodPocztowy() {
        return kodPocztowy;
    }

    public void setKodPocztowy(String kodPocztowy) {
        this.kodPocztowy = kodPocztowy;
    }

    public String getPoczta() {
        return poczta;
    }

    public void setPoczta(String poczta) {
        this.poczta = poczta;
    }

    public String getUlica() {
        return ulica;
    }

    public void setUlica(String ulica) {
        this.ulica = ulica;
    }

    public String getNrDomu() {
        return nrDomu;
    }

    public void setNrDomu(String nrDomu) {
        this.nrDomu = nrDomu;
    }

    public String getNrLokalu() {
        return nrLokalu;
    }

    public void setNrLokalu(String nrLokalu) {
        this.nrLokalu = nrLokalu;
    }

    // Getters and Setters
}
